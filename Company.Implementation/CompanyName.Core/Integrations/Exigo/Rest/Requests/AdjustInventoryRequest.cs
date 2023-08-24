// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AdjustInventoryRequest : ApiRequest
{
    public int WarehouseID { get; init; }
    public string ItemCode { get; init; }
    public int Quantity { get; init; }
    public string Notes { get; init; }

    public AdjustInventoryRequest() : base()
    {
        ItemCode = String.Empty;
        Notes = String.Empty;
    }
}
