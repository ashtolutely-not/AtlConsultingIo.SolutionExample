// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateWebCategoryRequest : ApiRequest
{
    public int WebID { get; init; }
    public int ParentID { get; init; }
    public string Description { get; init; }

    public CreateWebCategoryRequest( ) : base ( ) => Description = String.Empty;
}
