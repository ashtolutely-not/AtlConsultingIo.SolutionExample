// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CompanyNewsResponse
{
    public string Description { get; init; }
    public int NewsID { get; init; }
    public DateTime CreatedDate { get; init; }
    public NewsWebSettings WebSettings { get; init; }
    public NewsCompanySettings CompanySettings { get; init; }

    public CompanyNewsResponse( ) : base ( ) => Description = String.Empty;
}
