// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AddPartyGuestsRequest : ApiRequest
{
    public int PartyID { get; init; }
    public int[] GuestIDs { get; init; }

    public AddPartyGuestsRequest( ) : base ( ) => GuestIDs = new int[ 0 ];
}
