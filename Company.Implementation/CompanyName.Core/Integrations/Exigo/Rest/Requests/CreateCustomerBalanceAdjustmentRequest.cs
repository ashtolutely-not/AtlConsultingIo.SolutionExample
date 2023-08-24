// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateCustomerBalanceAdjustmentRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int CustomerTransactionTypeID { get; init; }
    public DateTime TransactionDate { get; init; }
    public Decimal Amount { get; init; }
    public string CurrencyCode { get; init; }
    public string Notes { get; init; }
    public string CustomerKey { get; init; }

    public CreateCustomerBalanceAdjustmentRequest() : base()
    {
        CurrencyCode = String.Empty;
        Notes = String.Empty;
        CustomerKey = String.Empty;
    }
}
