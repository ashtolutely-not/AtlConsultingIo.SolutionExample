// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateItemResponse : ApiResponse
{
    public int ItemID { get; init; }
    public string ItemCode { get; init; }

    public CreateItemResponse( ) : base ( ) => ItemCode = String.Empty;
}
