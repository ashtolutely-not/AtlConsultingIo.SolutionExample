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

[Table("EmailOutLog")]
[Index("CustomerId", "SubmitDate", Name = "IX_CID_SubmitDate_Inc_BCID")]
[Index("CustomerId", Name = "IX_EmailOutLog_CustomerID")]
public partial class EmailOutLog
{
    [Key]
    [Column("OutMailID")]
    public int OutMailId { get; set; }

    [Column("CustomerID")]
    public int? CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime SubmitDate { get; set; }

    [StringLength(200)]
    public string MailTo { get; set; } = null!;

    [StringLength(200)]
    public string Subject { get; set; } = null!;

    [Column("BroadCastID")]
    public int? BroadCastId { get; set; }

    [StringLength(500)]
    public string DeliveryStatus { get; set; } = null!;
}
