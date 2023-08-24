using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PeriodTypeId", "PeriodId")]
[Index("StartDate", "EndDate", "PeriodTypeId", "PeriodId", Name = "IX_StDtEndDt")]
public partial class Period
{
    [Key]
    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [Key]
    [Column("PeriodID")]
    public int PeriodId { get; set; }

    [StringLength(50)]
    public string PeriodDescription { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EndDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? AcceptedDate { get; set; }
}
