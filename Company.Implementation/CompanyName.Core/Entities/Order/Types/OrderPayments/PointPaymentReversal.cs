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

namespace CompanyName.Core.Entities.Order;

[JsonConverter ( typeof ( PointTransactionConverter ) )]
public record PointPaymentReversal : IOrderPointTransaction
{
    public CustomerID UserID { get ; init ; }
    public CartID CartID { get ; init ; }
    public PointAccountID PointAccountID { get; init; }
    public decimal TransactionAmount { get ; init ; }
    public DateTime TransactionDate { get; init; }
    public OrderID? OrderID { get; init; }
    public ExigoEntityID PaymentTransactionID { get; init; }
    public ExigoEntityID? TransactionID { get; set; }
    public string? ProcessingError { get; set; }

    public PointPaymentReversal( )
    {
            
    }

    public PointPaymentReversal( PointAccountPayment originalTransaction )
    {
        UserID = originalTransaction.UserID;
        CartID = originalTransaction.CartID;
        PointAccountID = originalTransaction.PointAccountID;
        TransactionAmount = -( originalTransaction.TransactionAmount );
        OrderID = originalTransaction.OrderID;
        PaymentTransactionID = originalTransaction.TransactionID.GetValueOrDefault(); 
    }
    public string TransactionReference => $"REVERSAL_{ PaymentTransactionID.Value }";

    public static readonly PointPaymentReversal Default = new();
}
