// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DeleteEntityResponse : ApiResponse
{
    public string schemaName { get; init; }
    public string EntityName { get; init; }

    public DeleteEntityResponse() : base()
    {
        schemaName = String.Empty;
        EntityName = String.Empty;
    }
}
