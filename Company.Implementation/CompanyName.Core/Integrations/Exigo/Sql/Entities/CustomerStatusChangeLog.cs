using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerStatusChangeLog")]
[Index("CustomerId", Name = "IX_CustomerStatusChangeLog_CustomerID")]
[Index("ModifiedDate", Name = "IX_ModDate_Inc")]
public partial class CustomerStatusChangeLog
{
    [Key]
    [Column("CustomerStatusChangeLogID")]
    public int CustomerStatusChangeLogId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("CustomerStatusID")]
    public int CustomerStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;
}
