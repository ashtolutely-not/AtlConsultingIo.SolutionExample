using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerTypeChangeLog")]
[Index("CustomerId", Name = "IX_CustomerTypeChangeLog_CustomerID")]
public partial class CustomerTypeChangeLog
{
    [Key]
    [Column("CustomerTypeChangeLogID")]
    public int CustomerTypeChangeLogId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("CustomerTypeID")]
    public int CustomerTypeId { get; set; }

    [Column("PrevousCustomerTypeID")]
    public int? PrevousCustomerTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;
}
