using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CustomerId", "VolumeTypeId")]
public partial class CommissionVolume
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Key]
    [Column("VolumeTypeID")]
    public int VolumeTypeId { get; set; }

    [Column(TypeName = "money")]
    public decimal Volume { get; set; }
}
