using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("OrderStatusChangeLog")]
[Index("OrderId", Name = "IX_OrderStatusChangeLog_OrderID")]
public partial class OrderStatusChangeLog
{
    [Key]
    [Column("OrderStatusChangeLogID")]
    public int OrderStatusChangeLogId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("OrderStatusID")]
    public int OrderStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;
}
