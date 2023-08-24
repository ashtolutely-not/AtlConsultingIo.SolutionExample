// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record LanguageResponse
{
    public int LanguageID { get; init; }
    public string Description { get; init; }
    public string CultureCode { get; init; }

    public LanguageResponse() : base()
    {
        Description = String.Empty;
        CultureCode = String.Empty;
    }
}
