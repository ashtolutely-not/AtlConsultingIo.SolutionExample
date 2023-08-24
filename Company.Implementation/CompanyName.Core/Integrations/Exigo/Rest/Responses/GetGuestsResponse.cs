// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetGuestsResponse : ApiResponse
{
    public GuestResponse[] Guests { get; init; }

    public GetGuestsResponse( ) : base ( ) => Guests = new GuestResponse[ 0 ];
}
