// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record StopSandboxRequest : ApiRequest
{
    public int SandboxID { get; init; }

    public StopSandboxRequest() : base()
    {
    }
}
