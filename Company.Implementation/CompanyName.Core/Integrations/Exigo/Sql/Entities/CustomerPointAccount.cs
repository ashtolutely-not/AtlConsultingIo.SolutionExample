using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("PointAccountId", "CustomerId")]
public partial class CustomerPointAccount
{
    [Key]
    [Column("PointAccountID")]
    public int PointAccountId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "money")]
    public decimal PointBalance { get; set; }
}
