using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CreditCardType
{
    [Key]
    [Column("CreditCardTypeID")]
    public int CreditCardTypeId { get; set; }

    [StringLength(100)]
    public string CreditCardTypeDescription { get; set; } = null!;
}
