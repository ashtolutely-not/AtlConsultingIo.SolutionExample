// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record PlaceUniLevelNodeRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int ToSponsorID { get; init; }
    public string Reason { get; init; }
    public int OptionalPlacement { get; init; }
    public bool OptionalFindAvailable { get; init; }
    public int OptionalUnilevelBuildTypeID { get; init; }
    public string CustomerKey { get; init; }
    public string ToSponsorKey { get; init; }

    public PlaceUniLevelNodeRequest() : base()
    {
        Reason = String.Empty;
        CustomerKey = String.Empty;
        ToSponsorKey = String.Empty;
    }
}
