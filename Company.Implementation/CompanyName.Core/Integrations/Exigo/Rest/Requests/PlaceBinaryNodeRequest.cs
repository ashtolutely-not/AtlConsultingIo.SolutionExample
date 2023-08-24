// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record PlaceBinaryNodeRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int ToParentID { get; init; }
    public BinaryPlacementType PlacementType { get; init; }
    public string Reason { get; init; }
    public string CustomerKey { get; init; }
    public string ToParentKey { get; init; }

    public PlaceBinaryNodeRequest() : base()
    {
        Reason = String.Empty;
        CustomerKey = String.Empty;
        ToParentKey = String.Empty;
    }
}
