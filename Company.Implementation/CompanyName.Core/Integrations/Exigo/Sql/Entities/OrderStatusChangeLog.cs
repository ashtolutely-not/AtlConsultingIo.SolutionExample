using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
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
