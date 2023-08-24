using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CommissionCurrentExchangeRate
{
    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Rate { get; set; }

    [Column(TypeName = "money")]
    public decimal Fee { get; set; }
}
