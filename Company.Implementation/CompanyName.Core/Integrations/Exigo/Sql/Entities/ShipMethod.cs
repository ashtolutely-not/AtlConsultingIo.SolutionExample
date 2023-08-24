using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ShipMethod
{
    [Key]
    [Column("ShipMethodID")]
    public int ShipMethodId { get; set; }

    [StringLength(50)]
    public string? ShipMethodDescription { get; set; }

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Column("ShipCarrierID")]
    public int ShipCarrierId { get; set; }

    public bool DisplayOnWeb { get; set; }
}
