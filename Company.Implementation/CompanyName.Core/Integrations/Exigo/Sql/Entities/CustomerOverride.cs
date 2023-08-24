using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PlanId", "OverrideId", "CustomerId")]
public partial class CustomerOverride
{
    [Key]
    [Column("PlanID")]
    public int PlanId { get; set; }

    [Key]
    [Column("OverrideID")]
    public int OverrideId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    public bool Qualifies { get; set; }

    [Column("PeriodTypeID")]
    public int? PeriodTypeId { get; set; }

    [Column("StartPeriodID")]
    public int? StartPeriodId { get; set; }

    [Column("EndPeriodID")]
    public int? EndPeriodId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }
}
