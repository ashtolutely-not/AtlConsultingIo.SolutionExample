using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CurrencyCode")]
public partial class CommissionExchangeRate
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Rate { get; set; }

    [Column(TypeName = "money")]
    public decimal Fee { get; set; }
}
