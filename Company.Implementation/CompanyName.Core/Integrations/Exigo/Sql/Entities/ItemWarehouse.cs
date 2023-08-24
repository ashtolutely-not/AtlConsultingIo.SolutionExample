using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("ItemId", "WarehouseId")]
public partial class ItemWarehouse
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Key]
    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    public int MaxAllowedOnOrder { get; set; }

    public int StockLevel { get; set; }
}
