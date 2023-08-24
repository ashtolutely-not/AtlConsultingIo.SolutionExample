using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PlanId", "OverrideId")]
public partial class Override
{
    [Key]
    [Column("PlanID")]
    public int PlanId { get; set; }

    [Key]
    [Column("OverrideID")]
    public int OverrideId { get; set; }

    [StringLength(200)]
    public string OverrideDescription { get; set; } = null!;
}
