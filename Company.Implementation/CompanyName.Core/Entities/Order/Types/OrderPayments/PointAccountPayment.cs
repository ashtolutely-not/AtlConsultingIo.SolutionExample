using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;

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
