using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("ItemId", "PointAccountId")]
public partial class ItemPointAccount
{
    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Key]
    [Column("PointAccountID")]
    public int PointAccountId { get; set; }

    [Column(TypeName = "money")]
    public decimal Increment { get; set; }
}
