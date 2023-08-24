// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetDownlineResponse : ApiResponse
{
    public NodeResponse[] Nodes { get; init; }
    public int RecordCount { get; init; }

    public GetDownlineResponse( ) : base ( ) => Nodes = new NodeResponse[ 0 ];
}
