using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerTempAuthRequest
{
    [Key]
    public int CustomerTempAuthRequestId { get; set; }

    public int CustomerId { get; set; }

    [MaxLength(255)]
    public byte[] Token { get; set; } = null!;

    public int RequestBy { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RequestDate { get; set; }

    [StringLength(15)]
    public string? RequestClientIp { get; set; }

    public Guid? RequestSessionId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ClaimDate { get; set; }
}
