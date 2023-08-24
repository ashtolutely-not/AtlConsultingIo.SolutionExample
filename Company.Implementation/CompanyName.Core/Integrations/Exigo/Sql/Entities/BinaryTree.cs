using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("BinaryTree")]
[Index("Lft", Name = "IX_BinaryTree_Lft")]
[Index("ParentId", Name = "IX_BinaryTree_ParentID")]
[Index("Lft", "Rgt", Name = "IX_LftRgt")]
public partial class BinaryTree
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("ParentID")]
    public int ParentId { get; set; }

    public int NestedLevel { get; set; }

    public int Placement { get; set; }

    public int Lft { get; set; }

    public int Rgt { get; set; }
}
