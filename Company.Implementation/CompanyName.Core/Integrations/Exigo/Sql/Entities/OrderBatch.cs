using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("WarehouseId", "BatchId", "PrintedDate")]
public partial class OrderBatch
{
    [Key]
    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Key]
    [Column("BatchID")]
    public int BatchId { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime PrintedDate { get; set; }

    public int TotalOrders { get; set; }
}
