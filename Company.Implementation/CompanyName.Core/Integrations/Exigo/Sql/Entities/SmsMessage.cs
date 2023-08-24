using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class SmsMessage
{
    [Key]
    [Column("MessageID")]
    public Guid MessageId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime MessageDate { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("SmsStatusID")]
    public int SmsStatusId { get; set; }

    [Column("ParentMessageID")]
    public Guid? ParentMessageId { get; set; }

    [StringLength(30)]
    public string FromNumber { get; set; } = null!;

    [StringLength(30)]
    public string ToNumber { get; set; } = null!;

    public string Message { get; set; } = null!;

    [StringLength(500)]
    public string? Exception { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [Column("BroadcastID")]
    public int? BroadcastId { get; set; }
}
