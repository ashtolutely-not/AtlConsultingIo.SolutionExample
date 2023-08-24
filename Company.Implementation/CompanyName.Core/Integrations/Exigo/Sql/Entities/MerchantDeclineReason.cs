using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class MerchantDeclineReason
{
    [Key]
    [Column("MerchantDeclineReasonID")]
    public int MerchantDeclineReasonId { get; set; }

    [StringLength(50)]
    public string MerchantDeclineReasonDescription { get; set; } = null!;
}
