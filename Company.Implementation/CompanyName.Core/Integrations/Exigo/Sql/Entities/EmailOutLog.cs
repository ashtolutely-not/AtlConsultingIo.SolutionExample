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
