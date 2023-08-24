// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetItemWarehouseRequest : ApiRequest, ITransactionMember
{
    public int[] AllowedUserWarehouses { get; init; }
    public int[] AllowedWarehouseManagementTypes { get; init; }
    public string ItemCode { get; init; }
    public int WarehouseID { get; init; }
    public bool? IsAvailable { get; init; }
    public int? ItemManageTypeID { get; init; }

    public SetItemWarehouseRequest() : base()
    {
        AllowedUserWarehouses = new int[0];
        AllowedWarehouseManagementTypes = new int[0];
        ItemCode = String.Empty;
    }
}
