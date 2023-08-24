// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record PlaceStackNodeRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }
    public int ToParentID { get; init; }
    public string ToParentKey { get; init; }
    public string Reason { get; init; }

    public PlaceStackNodeRequest() : base()
    {
        CustomerKey = String.Empty;
        ToParentKey = String.Empty;
        Reason = String.Empty;
    }
}
