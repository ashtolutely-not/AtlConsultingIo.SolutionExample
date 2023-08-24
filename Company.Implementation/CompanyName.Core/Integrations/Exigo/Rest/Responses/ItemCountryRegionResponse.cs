// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ItemCountryRegionResponse
{
    public string ItemCode { get; init; }
    public string CountryCode { get; init; }
    public string RegionCode { get; init; }
    public bool? Taxed { get; init; }
    public bool? TaxedFed { get; init; }
    public bool? TaxedState { get; init; }
    public bool? UseTaxOverride { get; init; }
    public Decimal? TaxOverridePct { get; init; }

    public ItemCountryRegionResponse() : base()
    {
        ItemCode = String.Empty;
        CountryCode = String.Empty;
        RegionCode = String.Empty;
    }
}
