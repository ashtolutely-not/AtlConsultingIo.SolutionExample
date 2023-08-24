// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetPaymentsRequest : ApiRequest
{
    public int? CustomerID { get; init; }
    public int? OrderID { get; init; }
    public string CustomerKey { get; init; }
    public string OrderKey { get; init; }

    public GetPaymentsRequest() : base()
    {
        CustomerKey = String.Empty;
        OrderKey = String.Empty;
    }
}
