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

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Broadcast
{
    [Key]
    [Column("BroadCastID")]
    public int BroadCastId { get; set; }

    [Column("BroadcastTypeID")]
    public int BroadcastTypeId { get; set; }

    [StringLength(255)]
    public string Subject { get; set; } = null!;

    public bool SendEmail { get; set; }

    public string EmailContent { get; set; } = null!;

    public bool SendSms { get; set; }

    public string SmsContent { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public bool IsEnabled { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
