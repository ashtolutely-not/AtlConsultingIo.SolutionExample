// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record Schema
{
    public string Name { get; init; }
    public Entity[] Entities { get; init; }

    public Schema() : base()
    {
        Name = String.Empty;
        Entities = new Entity[0];
    }
}
