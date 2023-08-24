// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePointTransactionRequest : ApiRequest
{
    public int PointAccountID { get; init; }
    public int CustomerID { get; init; }
    public Decimal Amount { get; init; }
    public string Reference { get; init; }
    public int PointTransactionTy { get; init; }
    public string CustomerKey { get; init; }

    public CreatePointTransactionRequest() : base()
    {
        Reference = String.Empty;
        CustomerKey = String.Empty;
    }
}
