using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerInquiryStatus
{
    [Key]
    [Column("CustomerInquiryStatusID")]
    public int CustomerInquiryStatusId { get; set; }

    [StringLength(50)]
    public string CustomerInquiryStatusDescription { get; set; } = null!;
}
