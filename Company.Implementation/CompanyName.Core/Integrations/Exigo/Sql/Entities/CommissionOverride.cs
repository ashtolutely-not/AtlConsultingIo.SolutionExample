using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CustomerId", "OverrideId")]
public partial class CommissionOverride
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    [Column("OverrideID")]
    public int OverrideId { get; set; }

    public bool Qualifies { get; set; }

    [Column("PeriodTypeID")]
    public int? PeriodTypeId { get; set; }

    [Column("StartPeriodID")]
    public int? StartPeriodId { get; set; }

    [Column("EndPeriodID")]
    public int? EndPeriodId { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }
}
