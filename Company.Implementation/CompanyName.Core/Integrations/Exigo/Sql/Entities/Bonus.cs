using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Bonus
{
    [Key]
    [Column("BonusID")]
    public int BonusId { get; set; }

    [StringLength(100)]
    public string BonusDescription { get; set; } = null!;

    [Column("PeriodTypeID")]
    public int PeriodTypeId { get; set; }
}
