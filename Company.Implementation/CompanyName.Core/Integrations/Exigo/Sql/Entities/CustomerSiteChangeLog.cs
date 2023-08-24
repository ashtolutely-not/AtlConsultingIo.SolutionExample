using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerSiteChangeLog")]
[Index("CustomerId", Name = "IX_CustomerSiteChangeLog_CustomerID")]
public partial class CustomerSiteChangeLog
{
    [Key]
    [Column("CustomerSiteChangeLogID")]
    public int CustomerSiteChangeLogId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;

    public string Detail { get; set; } = null!;
}
