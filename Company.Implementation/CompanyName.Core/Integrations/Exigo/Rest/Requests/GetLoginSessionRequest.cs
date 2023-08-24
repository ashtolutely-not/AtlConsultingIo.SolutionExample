// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetLoginSessionRequest : ApiRequest
{
    public string SessionID { get; init; }

    public GetLoginSessionRequest( ) : base ( ) => SessionID = String.Empty;
}
