using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class MerchantType
{
    [Key]
    [Column("MerchantTypeID")]
    public int MerchantTypeId { get; set; }

    [StringLength(50)]
    public string Description { get; set; } = null!;
}
