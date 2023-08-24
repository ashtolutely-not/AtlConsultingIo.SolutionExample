using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("AutoOrderStatusChangeLog")]
[Index("AutoOrderId", Name = "IX_AutoOrderStatusChangeLog_AutoOrderID")]
public partial class AutoOrderStatusChangeLog
{
    [Key]
    [Column("AutoOrderStatusChangeLogID")]
    public int AutoOrderStatusChangeLogId { get; set; }

    [Column("AutoOrderID")]
    public int AutoOrderId { get; set; }

    [Column("AutoOrderStatusID")]
    public int AutoOrderStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
