using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("MasterItemId", "ItemId")]
public partial class ItemStaticKitMember
{
    [Key]
    [Column("MasterItemID")]
    public int MasterItemId { get; set; }

    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    [Column(TypeName = "money")]
    public decimal Quantity { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
