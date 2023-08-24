using CompanyName.Core.Integrations.Exigo;

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
