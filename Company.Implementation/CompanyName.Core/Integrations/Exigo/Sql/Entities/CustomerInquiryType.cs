using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerInquiryType
{
    [Key]
    [Column("CustomerInquiryTypeID")]
    public int CustomerInquiryTypeId { get; set; }

    [StringLength(50)]
    public string CustomerInquiryTypeDescription { get; set; } = null!;
}
