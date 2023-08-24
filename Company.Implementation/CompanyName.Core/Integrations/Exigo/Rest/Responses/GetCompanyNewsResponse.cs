// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCompanyNewsResponse : ApiResponse
{
    public CompanyNewsResponse[] CompanyNews { get; init; }

    public GetCompanyNewsResponse( ) : base ( ) => CompanyNews = new CompanyNewsResponse[ 0 ];
}
