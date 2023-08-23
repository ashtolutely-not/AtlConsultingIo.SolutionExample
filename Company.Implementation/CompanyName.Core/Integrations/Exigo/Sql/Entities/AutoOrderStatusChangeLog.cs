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
