using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "VolumeTypeId")]
public partial class CommissionVolumeType
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("VolumeTypeID")]
    public int VolumeTypeId { get; set; }

    [StringLength(500)]
    public string VolumeTypeDescription { get; set; } = null!;
}
