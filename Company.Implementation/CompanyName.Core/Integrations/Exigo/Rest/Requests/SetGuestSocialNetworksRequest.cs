// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetGuestSocialNetworksRequest : ApiRequest
{
    public int GuestID { get; init; }
    public GuestSocialNetworkRequest[] GuestSocialNetworks { get; init; }

    public SetGuestSocialNetworksRequest( ) : base ( ) => GuestSocialNetworks = new GuestSocialNetworkRequest[ 0 ];
}
