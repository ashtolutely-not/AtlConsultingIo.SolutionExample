using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("WarehouseId", "CurrencyCode")]
public partial class WarehouseCurrency
{
    [Key]
    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    public int Priority { get; set; }
}
