// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record RemoveApiWhitelistRequest : ApiRequest
{
    public int IPRangeID { get; init; }

    public RemoveApiWhitelistRequest() : base()
    {
    }
}
