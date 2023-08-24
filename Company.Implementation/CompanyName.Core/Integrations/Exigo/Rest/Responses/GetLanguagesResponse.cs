// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetLanguagesResponse : ApiResponse
{
    public LanguageResponse[] CompanyLanguages { get; init; }

    public GetLanguagesResponse( ) : base ( ) => CompanyLanguages = new LanguageResponse[ 0 ];
}
