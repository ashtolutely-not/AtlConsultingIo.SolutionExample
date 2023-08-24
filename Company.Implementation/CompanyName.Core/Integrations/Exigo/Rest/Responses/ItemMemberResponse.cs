// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ItemMemberResponse
{
    public string ItemCode { get; init; }
    public string MemberDescription { get; init; }
    public string ItemDescription { get; init; }
    public InventoryStatusType InventoryStatus { get; init; }
    public int StockLevel { get; init; }
    public int AvailableStockLevel { get; init; }

    public ItemMemberResponse() : base()
    {
        ItemCode = String.Empty;
        MemberDescription = String.Empty;
        ItemDescription = String.Empty;
    }
}
