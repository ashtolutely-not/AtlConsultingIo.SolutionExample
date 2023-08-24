using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Integrations.Exigo;


namespace CompanyName.Operations.Checkout;

public record CheckoutResult
{
    public CartID CartId { get; init; }
    public CustomerID? AccountId { get; set; }
    public OrderID? OrderId { get; init; }
    public TransactionKey? PaymentAuthorization { get; init; }
    public ExigoEntityID? PaymentId { get; init; }
    public SalesOrderTotal FinalTotal { get; init; }

    public static readonly CheckoutResult Default = new();

}
