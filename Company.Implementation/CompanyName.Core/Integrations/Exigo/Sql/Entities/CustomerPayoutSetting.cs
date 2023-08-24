using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerPayoutSetting
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    public bool Produce1099 { get; set; }

    [Column("TaxAddressTypeID")]
    public int TaxAddressTypeId { get; set; }

    [Column("TaxNameTypeID")]
    public int TaxNameTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;
}
