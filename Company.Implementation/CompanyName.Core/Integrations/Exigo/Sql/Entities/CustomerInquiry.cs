using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_CustomerInquiries_CustomerID")]
public partial class CustomerInquiry
{
    [Key]
    [Column("CustomerInquiryID")]
    public int CustomerInquiryId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("CustomerInquiryTypeID")]
    public int CustomerInquiryTypeId { get; set; }

    [Column("CustomerInquiryCategoryID")]
    public int? CustomerInquiryCategoryId { get; set; }

    [Column("CustomerInquiryStatusID")]
    public int CustomerInquiryStatusId { get; set; }

    [Column("ParentID")]
    public int? ParentId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [StringLength(200)]
    public string Description { get; set; } = null!;

    public string Detail { get; set; } = null!;

    [StringLength(50)]
    public string? CreatedBy { get; set; }

    [StringLength(50)]
    public string? AssignedTo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ClosedDate { get; set; }

    [StringLength(50)]
    public string? ClosedBy { get; set; }

    [StringLength(200)]
    public string Reference { get; set; } = null!;
}
