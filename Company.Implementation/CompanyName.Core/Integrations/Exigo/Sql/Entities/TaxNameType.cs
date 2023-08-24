using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class TaxNameType
{
    [Key]
    [Column("TaxNameTypeID")]
    public int TaxNameTypeId { get; set; }

    [StringLength(50)]
    public string TaxNameTypeDescription { get; set; } = null!;
}
