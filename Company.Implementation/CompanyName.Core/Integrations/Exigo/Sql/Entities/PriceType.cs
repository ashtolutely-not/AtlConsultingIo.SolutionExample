using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PriceType
{
    [Key]
    [Column("PriceTypeID")]
    public int PriceTypeId { get; set; }

    [StringLength(50)]
    public string PriceTypeDescription { get; set; } = null!;
}
