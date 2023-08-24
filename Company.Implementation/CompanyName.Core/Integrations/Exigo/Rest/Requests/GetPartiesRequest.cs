// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetPartiesRequest : ApiRequest
{
    public int? PartyID { get; init; }
    public int? HostID { get; init; }
    public int? DistributorID { get; init; }
    public int? PartyStatusType { get; init; }
    public int? BookingPartyID { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }

    public GetPartiesRequest() : base()
    {
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
    }
}
