// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DeleteProductFromCategoryRequest : ApiRequest
{
    public int WebID { get; init; }
    public int CategoryID { get; init; }
    public string ItemCode { get; init; }

    public DeleteProductFromCategoryRequest( ) : base ( ) => ItemCode = String.Empty;
}
