// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetSandboxResponse : ApiResponse
{
    public Sandbox? Sandbox { get; init; }
    public Sandbox[] Sandboxes { get; init; }

    public GetSandboxResponse( ) : base ( ) => Sandboxes = new Sandbox[ 0 ];
}
