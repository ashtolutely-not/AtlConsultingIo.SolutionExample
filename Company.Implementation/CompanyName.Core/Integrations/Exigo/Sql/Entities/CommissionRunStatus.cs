using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CommissionRunStatus
{
    [Key]
    [Column("CommissionRunStatusID")]
    public int CommissionRunStatusId { get; set; }

    [StringLength(50)]
    public string CommissionRunStatusDescription { get; set; } = null!;
}
