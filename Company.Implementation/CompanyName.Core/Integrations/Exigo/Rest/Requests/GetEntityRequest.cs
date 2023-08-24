// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetEntityRequest : ApiRequest
{
    public string SchemaName { get; init; }
    public string EntityName { get; init; }

    public GetEntityRequest() : base()
    {
        SchemaName = String.Empty;
        EntityName = String.Empty;
    }
}
