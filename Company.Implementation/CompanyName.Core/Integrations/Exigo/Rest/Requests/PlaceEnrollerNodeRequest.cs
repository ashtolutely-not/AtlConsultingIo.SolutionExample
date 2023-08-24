// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record PlaceEnrollerNodeRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int ToEnrollerID { get; init; }
    public string Reason { get; init; }
    public string CustomerKey { get; init; }
    public string ToEnrollerKey { get; init; }

    public PlaceEnrollerNodeRequest() : base()
    {
        Reason = String.Empty;
        CustomerKey = String.Empty;
        ToEnrollerKey = String.Empty;
    }
}
