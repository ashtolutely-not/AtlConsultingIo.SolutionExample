using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("AutoOrderId", "ScheduledDate")]
public partial class AutoOrderSchedule
{
    [Key]
    [Column("AutoOrderID")]
    public int AutoOrderId { get; set; }

    [Key]
    [Column(TypeName = "datetime")]
    public DateTime ScheduledDate { get; set; }

    public bool IsEnabled { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ProcessedDate { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }
}
