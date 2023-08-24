// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CountryResponse
{
    public string CountryCode { get; init; }
    public string CountryName { get; init; }

    public CountryResponse() : base()
    {
        CountryCode = String.Empty;
        CountryName = String.Empty;
    }
}
