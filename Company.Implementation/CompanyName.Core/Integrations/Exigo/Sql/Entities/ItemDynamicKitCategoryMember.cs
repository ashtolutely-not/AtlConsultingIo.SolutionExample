using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("MasterItemId", "DynamicKitCategoryId")]
public partial class ItemDynamicKitCategoryMember
{
    [Key]
    [Column("MasterItemID")]
    public int MasterItemId { get; set; }

    [Key]
    [Column("DynamicKitCategoryID")]
    public int DynamicKitCategoryId { get; set; }

    [Column(TypeName = "money")]
    public decimal Quantity { get; set; }
}
