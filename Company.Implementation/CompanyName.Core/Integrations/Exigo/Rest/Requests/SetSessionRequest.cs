// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetSessionRequest : ApiRequest
{
    public string SessionID { get; init; }
    public string SessionData { get; init; }

    public SetSessionRequest() : base()
    {
        SessionID = String.Empty;
        SessionData = String.Empty;
    }
}
