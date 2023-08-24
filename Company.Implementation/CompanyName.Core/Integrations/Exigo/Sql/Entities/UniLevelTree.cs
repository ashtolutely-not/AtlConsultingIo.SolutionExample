using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("UniLevelTree")]
[Index("Lft", Name = "IX_UniLevelTree_Lft")]
[Index("SponsorId", Name = "IX_UniLevelTree_SponsorID")]
public partial class UniLevelTree
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("SponsorID")]
    public int SponsorId { get; set; }

    public int NestedLevel { get; set; }

    public int Placement { get; set; }

    public int Lft { get; set; }

    public int Rgt { get; set; }
}
