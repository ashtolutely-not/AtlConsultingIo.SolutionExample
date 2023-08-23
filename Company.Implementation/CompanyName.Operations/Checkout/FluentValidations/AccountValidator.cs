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
using System.Text.RegularExpressions;
using FluentValidation.Results;
using Polly;

namespace CompanyName.Operations.Checkout;
public class AccountValidator : AbstractValidator<AccountRegistration>
{
    public AccountValidator( )
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        // Required Values Exigo API && Business Rules
        RuleFor ( x => x.EnrollerID )
                .NotNull ( )
                .GreaterThan ( 0 )
                .When ( x => x.InsertEnrollerTree );
        RuleFor ( x => x.FirstName )
            .NotNull ( )
            .NotEmpty ( )
            .Length ( 3 , 50 )
            .WithMessage ( CheckoutErrors.RequiredValue ( nameof ( CreateCustomerRequest.FirstName ) ) );
        RuleFor ( x => x.LastName )
            .NotNull ( )
            .NotEmpty ( )
            .Length ( 3 , 50 )
            .WithMessage ( CheckoutErrors.RequiredValue ( nameof ( CreateCustomerRequest.LastName ) ) );
        RuleFor ( x => x.Phone )
           .NotNull ( )
           .NotEmpty ( )
           .Length ( 12 , 20 )
           .WithMessage ( CheckoutErrors.RequiredValue ( nameof ( CreateCustomerRequest.Phone ) ) );
        RuleFor ( x => x.Email ) //verify length constraints
            .NotNull ( )
            .NotEmpty ( )
            .EmailAddress ( )
            .Length ( 5 , 100 )
            .WithMessage ( CheckoutErrors.RequiredValue ( nameof ( CreateCustomerRequest.Email ) ) );
        RuleFor ( x => x.CurrencyCode )
            .NotNull ( )
            .NotEmpty ( )
            .Length ( 3 )
            .WithMessage ( CheckoutErrors.RequiredValue ( nameof ( CreateCustomerRequest.CurrencyCode ) ) );

        RuleFor ( x => x.CustomerStatus )
            .NotNull ( )
            .GreaterThan ( 0 );
        RuleFor ( x => x.DefaultWarehouseID )
            .NotNull ( )
            .NotEmpty ( )
            .GreaterThan ( 0 );

        RuleFor ( x => x.LanguageID )
            .NotNull ( )
            .GreaterThanOrEqualTo ( 0 );
        RuleFor ( x => x.SubscribeFromIPAddress )
            .NotNull ( )
            .NotEmpty ( )
            .When ( x => x.SubscribeToBroadcasts.Equals ( true ) );
        RuleFor ( x => x.Company )
            .Length ( 3 , 50 )
            .When ( x => x.Company.HasValue ( ) );
        RuleFor ( x => x.Phone2 )
            .Length ( 12 , 20 )
            .When ( x => x.Phone2.HasValue ( ) );
        RuleFor ( x => x.MobilePhone )
            .Length ( 12 , 20 )
            .When ( x => x.MobilePhone.HasValue ( ) );
        RuleFor ( x => x.MainAddress2 )
            .Length ( 2 , 34 )
            .When ( x => x.MainAddress2.HasValue ( ) );
        RuleFor ( x => x.MainAddress3 )
            .Length ( 2 , 34 )
            .When ( x => x.MainAddress3.HasValue ( ) );
        RuleFor ( x => x.MailAddress2 )
            .Length ( 2 , 34 )
            .When ( x => x.MailAddress2.HasValue ( ) );
        RuleFor ( x => x.MailAddress3 )
            .Length ( 2 , 34 )
            .When ( x => x.MailAddress3.HasValue ( ) );
        RuleFor ( x => x.OtherAddress2 )
            .Length ( 2 , 34 )
            .When ( x => x.OtherAddress2.HasValue ( ) );
        RuleFor ( x => x.OtherAddress3 )
            .Length ( 2 , 34 )
            .When ( x => x.OtherAddress3.HasValue ( ) );


        // EXIGO API BEHAVIOR 
        When ( x => x.MainAddress1.HasValue ( ) , ( ) =>
        {
            RuleFor ( x => x.MainCity )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 100 );
            RuleFor ( x => x.MainState )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 100 );
            RuleFor ( x => x.MainZip )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 3 , 10 );
            RuleFor ( x => x.MainCountry )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 50 );
            RuleFor ( x => x.MainAddressVerified )
                .NotNull ( );
        } );
        When ( x => x.MailAddress1.HasValue ( ) , ( ) =>
        {
            RuleFor ( x => x.MailCity )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 100 );
            RuleFor ( x => x.MailState )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 100 );
            RuleFor ( x => x.MailZip )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 3 , 10 );
            RuleFor ( x => x.MailCountry )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 50 );
            RuleFor ( x => x.MailAddressVerified )
                .NotNull ( );
        } );
        When ( x => x.OtherAddress1.HasValue ( ) , ( ) =>
        {
            RuleFor ( x => x.OtherCity )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 100 );
            RuleFor ( x => x.OtherState )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 100 );
            RuleFor ( x => x.OtherZip )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 3 , 10 );
            RuleFor ( x => x.OtherCountry )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 50 );
            RuleFor ( x => x.OtherAddressVerified )
                .NotNull ( );
        } );

        When( (account,context) => HasBirthdateRequirement( context ), () =>
        {
            RuleFor ( x => x.BirthDate ).Custom ( ( x , context ) =>
            {
                CheckoutContext? checkoutCtx = GetCheckoutContext( context );
                if ( checkoutCtx is not CheckoutContext _checkoutCtx )
                {
                    context.AddFailure ( $"{ValidationContextKeys.Context} not found for birthdate business rule validation" );
                    return;
                }

                if ( !IsBirthdateValid ( x ) )
                    context.AddFailure ( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.BirthDate ) ) );
            } );
        } );

        When ( ( account , context ) => UserSelectedEnrollerRequired ( context ) , ( ) =>
        {
            RuleFor ( x => x.EnrollerID ).Custom ( ( x , context ) =>
            {
                ExigoConfiguration exigoConfig = GetExigoConfiguration( context  );
                if ( x.Equals ( 0 ) || x.Equals ( exigoConfig.Checkout.Defaults.EnrollerID ) )
                    context.AddFailure ( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.EnrollerID ) ) );
            } );
        } );

        When ( ( account , context ) => HasTaxIdRequirement ( context ) , ( ) =>
        {
            RuleFor ( x => x.TaxID ).Custom ( ( taxId , context ) =>
            {
                if ( !taxId.HasValue ( ) || !Regex.Match ( taxId , SpecialCharacterPattern ).Success )
                {
                    context.AddFailure ( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.TaxID ) ) );
                    return;
                }

                var rules = GetAccountRules ( context );
                var validator = rules.TaxIDValidations
                                                .FirstOrDefault( i => i.TaxCountryCode.CaseInsensitiveEquals( context.InstanceToValidate.MainCountry ) );
                
                if( validator is not null )
                    if( !validator.Validate ( taxId ) )
                        context.AddFailure ( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.TaxID ) ) );
            } );
        } );

        When (( x ,ctx)  => IsGuestCart( ctx ).Equals( false ) , ( ) =>
        {
            RuleFor ( x => x.LoginName )
                .NotNull()
                .NotEmpty()
                .Length ( 6 , 50 )
                .WithMessage( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.LoginName ) ) );

            RuleFor ( x => x.LoginName ).Custom ( ( value , context ) =>
                {
                    AccountRegistrationRules? rules = context.RootContextData.TryGetValue( ValidationContextKeys.AccountRules, out var obj) ? obj as AccountRegistrationRules : null;
                    if ( rules is null || !rules.AccountUsernameRegexValidator.HasValue ( ) )
                        return;
                    if ( !Regex.Match ( value , rules.AccountUsernameRegexValidator! ).Success )
                        context.AddFailure ( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.LoginName ) ) );
                } );
            RuleFor ( x => x.LoginPassword )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 8 , 40 )
                .WithMessage( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.LoginPassword ) ) );

            RuleFor ( x => x.LoginPassword )
                .Custom ( ( value , context ) =>
                {
                    AccountRegistrationRules? rules = context.RootContextData.TryGetValue( ValidationContextKeys.AccountRules, out var obj) ? obj as AccountRegistrationRules : null;
                    if ( rules is null || !rules.AccountPasswordRegexValidator.HasValue ( ) )
                        return;
                    if ( !Regex.Match ( value , rules.AccountPasswordRegexValidator! ).Success )
                        context.AddFailure ( CheckoutErrors.InvalidValue ( nameof ( AccountRegistration.LoginPassword ) ) );
                } );

            RuleFor ( x => x!.MainAddress1 )
                .NotNull ( )
                .NotEmpty ( )
                .Length ( 2 , 34 )
                .WithMessage ( CheckoutErrors.RequiredValue ( "Address" ) );
        } );

    }

    private static CheckoutContext? GetCheckoutContext( ValidationContext<AccountRegistration> validationContext )
        => validationContext.RootContextData.TryGetValue ( ValidationContextKeys.Context , out var obj ) ? obj as CheckoutContext : null;
    private static bool UserSelectedEnrollerRequired( ValidationContext<AccountRegistration> context )
        => GetCheckoutContext ( context )?.AccountType.EnrollerRequiredOnCreate ?? true;
    private static bool HasBirthdateRequirement( ValidationContext<AccountRegistration> context )
        => GetCheckoutContext ( context )?.AccountType.HasBirthdateRequirement ?? true;
    private static bool HasTaxIdRequirement( ValidationContext<AccountRegistration> context )
        => GetCheckoutContext ( context )?.AccountType.TaxIDRequiredOnCreate ?? true;
    private static bool IsGuestCart( ValidationContext<AccountRegistration> context )
        => GetCheckoutContext ( context )?.IsGuestCart ?? false;

    private static AccountRegistrationRules GetAccountRules( ValidationContext<AccountRegistration> validationContext )
        => validationContext.GetRootContextValue<AccountRegistration,AccountRegistrationRules>( ValidationContextKeys.AccountRules ) ?? AccountRegistrationRules.Default;
    private static ExigoConfiguration GetExigoConfiguration( ValidationContext<AccountRegistration> context )
    {
        if( context.RootContextData.TryGetValue ( ValidationContextKeys.ExigoConfiguration , out var config ) )
            if( config is ExigoConfiguration _exigo )
                return _exigo;

           return ExigoConfiguration.Instance;
    }

    protected override bool PreValidate( ValidationContext<AccountRegistration> context , ValidationResult result )
    {
        if ( context.InstanceToValidate is null )
        {
            result.Errors.Add ( new ValidationFailure ( nameof ( AccountRegistration ) , "Account registratration is null." ) );
            return Valid.False;
        }
        return Valid.True;
    }

    private static Valid IsBirthdateValid( DateTime? birthdate )
    {
        if ( !birthdate.HasValue )
            return Valid.False;

        DateTime value = birthdate.Value;
        if ( IsDefaultDate ( value ) )
            return Valid.False;

        DateOnly required = DateOnly.FromDateTime(DateTime.UtcNow).AddYears(-18);
        DateOnly actual = DateOnly.FromDateTime(value);

        return actual >= required ? Valid.True : Valid.False;
    }
    private static bool IsDefaultDate( DateTime date ) => date.Equals ( new DateTime ( ) );
    private static readonly string SpecialCharacterPattern = @"[a-zA-Z0-9]+";
}

