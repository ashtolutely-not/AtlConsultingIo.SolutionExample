using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PeriodType
{
    [Key]
    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }

    [StringLength(50)]
    public string PeriodTypeDescription { get; set; } = null!;
}
