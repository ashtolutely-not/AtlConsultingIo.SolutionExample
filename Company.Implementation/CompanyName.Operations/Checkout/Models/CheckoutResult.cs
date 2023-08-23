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
