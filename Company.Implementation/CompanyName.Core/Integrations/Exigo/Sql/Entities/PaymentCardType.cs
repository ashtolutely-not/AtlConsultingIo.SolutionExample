using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PaymentCardType
{
    [Key]
    [Column("PaymentCardTypeID")]
    public int PaymentCardTypeId { get; set; }

    [StringLength(50)]
    public string PaymentCardTypeDescription { get; set; } = null!;
}
