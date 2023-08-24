// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record RegionResponse
{
    public string RegionCode { get; init; }
    public string RegionName { get; init; }

    public RegionResponse() : base()
    {
        RegionCode = String.Empty;
        RegionName = String.Empty;
    }
}
