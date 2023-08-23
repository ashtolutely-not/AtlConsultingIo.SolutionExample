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
