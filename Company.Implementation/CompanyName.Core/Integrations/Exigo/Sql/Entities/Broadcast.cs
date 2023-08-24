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
