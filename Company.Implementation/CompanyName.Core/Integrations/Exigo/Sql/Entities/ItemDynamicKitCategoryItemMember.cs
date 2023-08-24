using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("DynamicKitCategoryId", "ItemId")]
public partial class ItemDynamicKitCategoryItemMember
{
    [Key]
    [Column("DynamicKitCategoryID")]
    public int DynamicKitCategoryId { get; set; }

    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }
}
