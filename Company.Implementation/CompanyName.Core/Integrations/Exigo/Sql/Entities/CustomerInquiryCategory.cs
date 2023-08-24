using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerInquiryCategory
{
    [Key]
    [Column("CustomerInquiryCategoryID")]
    public int CustomerInquiryCategoryId { get; set; }

    [StringLength(100)]
    public string CustomerInquiryCategoryDescription { get; set; } = null!;
}
