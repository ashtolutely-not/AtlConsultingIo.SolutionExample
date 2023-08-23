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
[JsonConverter(typeof(PointTransactionConverter))]
public record PointAccountPayment : IOrderPointTransaction
{
    public CustomerID UserID { get; init; }
    public CartID CartID { get; init; }
    public PointAccountID PointAccountID { get; init; }
    public decimal TransactionAmount { get; init; }
    public ExigoEntityID? TransactionID { get; set; } 
    public OrderID? OrderID { get; init; } 
    public DateTime TransactionDate { get; init; } 
    public string? ProcessingError { get; set; }

    public string TransactionReference 
        => $"{nameof(CartID)}_{(string)CartID}";

    public static readonly PointAccountPayment Default = new();
}
