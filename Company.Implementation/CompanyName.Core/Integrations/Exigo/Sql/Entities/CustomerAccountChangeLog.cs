using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerAccountChangeLog")]
[Index("CustomerId", Name = "IX_CustomerAccountChangeLog_CustomerID")]
public partial class CustomerAccountChangeLog
{
    [Key]
    [Column("CustomerAccountChangeLogID")]
    public int CustomerAccountChangeLogId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;

    public string Detail { get; set; } = null!;
}
