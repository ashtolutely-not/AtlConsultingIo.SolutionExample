using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class TaxAddressType
{
    [Key]
    [Column("TaxAddressTypeID")]
    public int TaxAddressTypeId { get; set; }

    [StringLength(50)]
    public string TaxAddressTypeDescription { get; set; } = null!;
}
