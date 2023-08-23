using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using FluentValidation;

using FluentValidation.Results;
using Polly;

namespace CompanyName.Operations.Checkout;
public class OrderValidator : AbstractValidator<ShoppingCartOrder>
{
    public OrderValidator()
    {
        RuleLevelCascadeMode = CascadeMode.Stop;
        ClassLevelCascadeMode = CascadeMode.Stop;

        //Required
        RuleFor( x => x.FirstName )
            .NotNull()
            .NotEmpty()
            .Length( 3 , 50 )
            .WithMessage( CheckoutErrors.RequiredValue( nameof(CreateOrderRequest.FirstName)) );
        RuleFor( x => x.LastName )
            .NotNull()
            .NotEmpty()
            .Length( 3 , 50 )
            .WithMessage( CheckoutErrors.RequiredValue( nameof(CreateOrderRequest.LastName)) );

        RuleFor( x => x.Email )
            .NotNull()
            .NotEmpty()
            .EmailAddress()
            .Length( 3 , 50 )
            .WithMessage( CheckoutErrors.RequiredValue( nameof(CreateOrderRequest.Email)) );
        RuleFor( x => x.Phone )
            .NotNull()
            .NotEmpty()
            .Length( 7 , 20 )
            .WithMessage( CheckoutErrors.RequiredValue( nameof(CreateOrderRequest.Phone)) );
        RuleFor( x => x.Address1 )
            .NotNull()
            .NotEmpty()
            .Length( 2 , 100 )
            .WithMessage( CheckoutErrors.RequiredValue( "Address" ) );
        RuleFor( x => x.City )
            .NotNull()
            .NotEmpty()
            .Length( 2 , 100 )
            .WithMessage( CheckoutErrors.RequiredValue( "Address" + nameof(CreateOrderRequest.City)) );
        RuleFor( x => x.State )
            .NotNull()
            .NotEmpty()
            .Length( 2 , 100 )
            .WithMessage( CheckoutErrors.RequiredValue( "Address State | Region") );
        RuleFor( x => x.Zip )
            .NotNull()
            .NotEmpty()
            .Length( 2 , 50 )
            .WithMessage( CheckoutErrors.RequiredValue( "Postal Code" ));
        RuleFor( x => x.Country )
            .NotNull()
            .NotEmpty()
            .Length( 2 )
            .WithMessage( CheckoutErrors.RequiredValue( "Address" + nameof(CreateOrderRequest.Country)) );
        RuleFor( x => x.Details )
            .Must( x => x.Count() > 0 )
            .WithMessage( CheckoutErrors.OrderDetailsMinimum );

        // Platform requirements
        RuleFor( x => x.CurrencyCode )
            .NotNull()
            .NotEmpty()
            .Length( 3 );
        RuleFor( x => x.PriceType )
            .GreaterThan(0);
        RuleFor( x => x.WarehouseID )
            .GreaterThan( 0 );
        RuleFor( x => x.ShipMethodID )
            .GreaterThan( 0 );

        //Database overflow
        RuleFor( x => x.Company )
            .Length( 3 , 50 )
            .When( x => x.Company.HasValue() );
        RuleFor( x => x.Address2 )
            .Length( 2 , 100 )
            .When( x => x.Address2.HasValue() );
        RuleFor( x => x.Address3 )
            .Length( 2 , 100 )
            .When( x => x.Address3.HasValue() );
        RuleFor( x => x.Notes )
            .Length( 0 , 500 );

        RuleForEach( x => x.Details )
            .SetValidator( new OrderDetailRequestValidator() );

        When((order,context) => IsEnrollmentOrder( context ), () =>
        {
            RuleFor( o => o.Details).Custom( (details,ctx) =>
            {
                var rules = GetBusinessRules( ctx );
                var actual = details.Sum ( x => x.BusinessVolumeEachOverride ) ?? 0;
                if ( actual >= rules.EnrollmentVolumeMinimum )
                    return;

                ctx.AddFailure ( CheckoutErrors.InsufficientEnrollmentVolume( actual, rules ) );

            } );

            RuleFor ( o => o.Details ).Custom ( ( details , ctx ) =>
            {
                var _rules = GetBusinessRules( ctx );
                var checkoutContext = ctx.GetRootContextValue<ShoppingCartOrder,CheckoutContext>( ValidationContextKeys.Context );
                int count = checkoutContext?.ProductContext.EnrollmentKitItemCount ?? 0;

                ctx.AddFailure ( CheckoutErrors.InvalidKitCount ( count , _rules ) );

            } );

        } );

    }

    protected override bool PreValidate( ValidationContext<ShoppingCartOrder> context , ValidationResult result )
    {
        if ( context.InstanceToValidate is null )
        {
            result.Errors.Add ( new ValidationFailure ( nameof ( ShoppingCartOrder ) , "Order request is null." ) );
            return Valid.False;
        }
        return Valid.True;
    }

    class OrderDetailRequestValidator : AbstractValidator<OrderDetailRequest>
    {
        public OrderDetailRequestValidator( )
        {
            ClassLevelCascadeMode = CascadeMode.Stop;

            RuleFor ( x => x.ItemCode )
                .NotEmpty ( )
                .Length ( 1 , 25 );
            RuleFor ( x => x.Quantity )
                .GreaterThan ( 0 );

            RuleSet ( "CommerceCloudRules" , ( ) =>
            {
                RuleFor ( x => x!.PriceEachOverride )
                    .NotNull ( );
                RuleFor ( x => x!.Other6EachOverride )
                    .NotNull ( );
                RuleFor ( x => x!.BusinessVolumeEachOverride )
                    .NotNull ( );
                RuleFor ( x => x!.CommissionableVolumeEachOverride )
                    .NotNull ( );
                RuleFor ( x => x!.Other1EachOverride )
                    .NotNull ( );
                RuleFor ( x => x!.Other2EachOverride )
                    .NotNull ( );
            } );


        }
    }

    private static AccountRegistrationRules GetBusinessRules( ValidationContext<ShoppingCartOrder> context )
    {
        AccountRegistrationRules? rules = context.RootContextData.TryGetValue( ValidationContextKeys.AccountRules , out var obj ) ? obj as AccountRegistrationRules : null;
        return rules ?? AccountRegistrationRules.Default;
    }
    private static bool IsEnrollmentOrder( ValidationContext<ShoppingCartOrder> context )
    {
        CheckoutContext? checkoutContext = context.RootContextData.TryGetValue( ValidationContextKeys.Context , out var obj ) ? obj as CheckoutContext : null;
        return checkoutContext?.IsEnrollmentCart ?? false;
    }

}
