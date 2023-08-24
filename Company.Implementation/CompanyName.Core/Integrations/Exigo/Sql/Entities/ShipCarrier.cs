using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ShipCarrier
{
    [Key]
    [Column("ShipCarrierID")]
    public int ShipCarrierId { get; set; }

    [StringLength(50)]
    public string ShipCarrierDescription { get; set; } = null!;

    [StringLength(255)]
    public string? TrackingUrl { get; set; }
}
