using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("EnrollerTree")]
[Index("EnrollerId", Name = "IX_EnrollerTree_EnrollerID")]
[Index("Lft", Name = "IX_EnrollerTree_Lft")]
[Index("Lft", "Rgt", Name = "IX_LftRgt")]
public partial class EnrollerTree
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("EnrollerID")]
    public int EnrollerId { get; set; }

    public int NestedLevel { get; set; }

    public int Lft { get; set; }

    public int Rgt { get; set; }
}
