using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class BinaryPlacementType
{
    [Key]
    [Column("BinaryPlacementTypeID")]
    public int BinaryPlacementTypeId { get; set; }

    [StringLength(50)]
    public string BinaryPlacementDescription { get; set; } = null!;
}
