using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PeriodTypeId", "PeriodId", "CustomerId", "PaidRankId")]
[Index("CustomerId", "Score", Name = "IX_PeriodRankScore")]
public partial class PeriodRankScore
{
    [Key]
    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [Key]
    [Column("PeriodID")]
    public int PeriodId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    [Column("PaidRankID")]
    public int PaidRankId { get; set; }

    [Column(TypeName = "money")]
    public decimal Score { get; set; }
}
