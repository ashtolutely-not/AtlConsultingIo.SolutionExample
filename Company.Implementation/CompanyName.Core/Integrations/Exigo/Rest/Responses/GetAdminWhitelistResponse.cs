// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetAdminWhitelistResponse : ApiResponse
{
    public AdminWhitelistResponse[] WhitelistRanges { get; init; }

    public GetAdminWhitelistResponse( ) : base ( ) => WhitelistRanges = new AdminWhitelistResponse[ 0 ];
}
