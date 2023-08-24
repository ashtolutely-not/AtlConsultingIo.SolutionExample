using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class AutoOrderPaymentType
{
    [Key]
    [Column("AutoOrderPaymentTypeID")]
    public int AutoOrderPaymentTypeId { get; set; }

    [StringLength(50)]
    public string AutoOrderPaymentTypeDescription { get; set; } = null!;
}
