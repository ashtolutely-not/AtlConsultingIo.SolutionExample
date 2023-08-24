// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record KitMemberItemResponse
{
    public string ItemCode { get; init; }
    public string Description { get; init; }
    public InventoryStatusType InventoryStatus { get; init; }

    public KitMemberItemResponse() : base()
    {
        ItemCode = String.Empty;
        Description = String.Empty;
    }
}
