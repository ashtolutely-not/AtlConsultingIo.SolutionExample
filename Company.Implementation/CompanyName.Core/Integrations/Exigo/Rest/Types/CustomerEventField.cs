// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CustomerEventField
{
    public string Name { get; init; }
    public int Value { get; init; }

    public CustomerEventField( ) : base ( ) => Name = String.Empty;
}
