using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CustomerId")]
[Table("CommissionUniLevelTree")]
public partial class CommissionUniLevelTree
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("SponsorID")]
    public int SponsorId { get; set; }

    public int NestedLevel { get; set; }

    public int Lft { get; set; }

    public int Rgt { get; set; }
}
