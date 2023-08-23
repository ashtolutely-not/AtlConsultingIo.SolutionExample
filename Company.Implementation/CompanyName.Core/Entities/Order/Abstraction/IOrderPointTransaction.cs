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

public interface IOrderPointTransaction
{
    CustomerID UserID { get; init; }
    CartID CartID { get; init; }
    PointAccountID PointAccountID { get; init; }
    decimal TransactionAmount { get; init; }
    DateTime TransactionDate { get; init; }
    OrderID? OrderID { get; init; }
    ExigoEntityID? TransactionID { get; set; }
    string? ProcessingError { get; set; }
    string TransactionReference { get; }
}
