using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("AutoOrderChangeLog")]
[Index("AutoOrderId", Name = "IX_AutoOrderChangeLog_AutoOrderID")]
public partial class AutoOrderChangeLog
{
    [Key]
    [Column("AutoOrderChangeLogID")]
    public int AutoOrderChangeLogId { get; set; }

    [Column("AutoOrderID")]
    public int AutoOrderId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;

    public string Detail { get; set; } = null!;
}
