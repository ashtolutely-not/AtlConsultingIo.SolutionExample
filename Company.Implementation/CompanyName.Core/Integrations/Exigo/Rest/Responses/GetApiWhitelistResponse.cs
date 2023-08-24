// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetApiWhitelistResponse : ApiResponse
{
    public ApiWhitelistResponse[] WhitelistRanges { get; init; }

    public GetApiWhitelistResponse( ) : base ( ) => WhitelistRanges = new ApiWhitelistResponse[ 0 ];
}
