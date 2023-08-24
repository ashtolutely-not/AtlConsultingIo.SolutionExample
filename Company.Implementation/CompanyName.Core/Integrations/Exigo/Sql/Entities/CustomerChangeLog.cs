using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerChangeLog")]
[Index("CustomerId", Name = "IX_CustomerChangeLog_CustomerID")]
[Index("ModifiedDate", "ModifiedBy", Name = "IX_ModDte")]
public partial class CustomerChangeLog
{
    [Key]
    [Column("CustomerChangeLogID")]
    public int CustomerChangeLogId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(100)]
    public string ModifiedBy { get; set; } = null!;

    [StringLength(4000)]
    public string Detail { get; set; } = null!;
}
