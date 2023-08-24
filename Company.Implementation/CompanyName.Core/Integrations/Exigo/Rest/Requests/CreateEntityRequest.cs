// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateEntityRequest : ApiRequest
{
    public Entity? Entity { get; init; }

    public CreateEntityRequest() : base()
    {
    }
}
