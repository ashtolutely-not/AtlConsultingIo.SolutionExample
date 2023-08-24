using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class TaxCodeType
{
    [Key]
    [Column("TaxCodeTypeID")]
    public int TaxCodeTypeId { get; set; }

    [StringLength(50)]
    public string TaxCodeDescription { get; set; } = null!;
}
