using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("AcceptedDate", Name = "IX_AcceptedDate_Inc")]
[Index("CommissionRunId", "PeriodTypeId", "PeriodId", Name = "IX_CommRunIDPeriodTypeIDPeriodID")]
[Index("CommissionRunStatusId", "CommissionRunId", Name = "IX_CommRunStID")]
public partial class CommissionRun
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [StringLength(100)]
    public string CommissionRunDescription { get; set; } = null!;

    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [Column("PeriodID")]
    public int PeriodId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? RunDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AcceptedDate { get; set; }

    [Column("CommissionRunStatusID")]
    public int CommissionRunStatusId { get; set; }

    public bool HideFromWeb { get; set; }

    [Column("PlanID")]
    public int? PlanId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ArchivedDate { get; set; }
}
