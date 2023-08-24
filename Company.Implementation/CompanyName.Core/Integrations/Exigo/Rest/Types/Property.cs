// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record Property
{
    public string Name { get; init; }
    public bool IsKey { get; init; }
    public bool IsNew { get; init; }
    public bool IsAutoNumber { get; init; }
    public bool AllowDbNull { get; init; }
    public PropertyType Type { get; init; }
    public string DefaultName { get; init; }
    public string DefaultValue { get; init; }
    public int? Size { get; init; }
    public string AutoGenerate { get; init; }

    public Property() : base()
    {
        Name = String.Empty;
        DefaultName = String.Empty;
        DefaultValue = String.Empty;
        AutoGenerate = String.Empty;
    }
}
