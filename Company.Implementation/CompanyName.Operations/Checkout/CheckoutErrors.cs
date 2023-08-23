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

namespace CompanyName.Operations.Checkout;
public static class CheckoutErrors
{
    public const string EmptyCartID = "CartID is empty, a valid CartID is required to process checkout request.";
    public static string OrderExists( OrderID orderID , CartID cartId )
        => $"Order already exists for shopping cart. [ CartID:  {cartId.Value} | OrderID : {orderID.Value} ]";
    public static string DuplicateRequest( CartID cartID ) 
        => $"Checkout already in progress for shopping cart. [ CartID: { cartID.Value } ]";

    public static string RequiredValue( string name )
        => $"{name} is required.";
    public static string InvalidValue( string name )
       => $"Invalid value for { name } detected.";
    
    public static string InsufficientPointBalance( decimal paymentAmount , decimal balanceTotal )
        => $"Point account balance of {balanceTotal.ToUSD()} is less than the reqested point payment amount ({paymentAmount.ToUSD()}).";

    public static string Unknown( CartID cartId )
        => $"Unknown error occurred while processing cart. [ CartID: { cartId.Value } ]";

    public const string OrderDetailsMinimum = "Order must contain at least one item.";

    public static string InsufficientEnrollmentVolume( decimal actualVolume , AccountRegistrationRules rules )
       => string.Format (
            "Enrollment cart must contain at least {min} in qualifying volume. Actual Volume: {actual}" ,
             rules.EnrollmentVolumeMinimum ,
             actualVolume
           );
    public static string InvalidKitCount( int actualCount , AccountRegistrationRules rules )
        => string.Format (
                "Enrollment cart must contain between {min} and {max} enrollment kits. Actual count: {actual}" ,
                rules.EnrollmentKitLimitMinimum ,
                rules.EnrollmentKitLimitMaximum ,
                actualCount
            );

    public static string UnsupportedPaymentType( Type actualType )
        => $"Unsupported merchant payment type of {actualType.Name}";
}
