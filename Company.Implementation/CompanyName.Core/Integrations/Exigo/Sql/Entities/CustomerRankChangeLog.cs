using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("CustomerRankChangeLog")]
[Index("CustomerId", Name = "IX_CustomerRankChangeLog_CustomerID")]
public partial class CustomerRankChangeLog
{
    [Key]
    [Column("CustomerRankChangeLogID")]
    public int CustomerRankChangeLogId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("RankID")]
    public int? RankId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
