// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AddProductsToCategoryRequest : ApiRequest
{
    public int WebID { get; init; }
    public int CategoryID { get; init; }
    public string[] ItemCodes { get; init; }

    public AddProductsToCategoryRequest( ) : base ( ) => ItemCodes = new string[ 0 ];
}
