// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCountryRegionsResponse : ApiResponse
{
    public CountryResponse[] Countries { get; init; }
    public string SelectedCountry { get; init; }
    public RegionResponse[] Regions { get; init; }

    public GetCountryRegionsResponse() : base()
    {
        Countries = new CountryResponse[0];
        SelectedCountry = String.Empty;
        Regions = new RegionResponse[0];
    }
}
