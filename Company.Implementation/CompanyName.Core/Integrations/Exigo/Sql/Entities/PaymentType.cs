using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PaymentType
{
    [Key]
    [Column("PaymentTypeID")]
    public int PaymentTypeId { get; set; }

    [StringLength(50)]
    public string PaymentTypeDescription { get; set; } = null!;
}
