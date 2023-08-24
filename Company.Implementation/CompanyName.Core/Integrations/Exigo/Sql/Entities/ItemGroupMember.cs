using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("MasterItemId", "ItemId")]
public partial class ItemGroupMember
{
    [Key]
    [Column("MasterItemID")]
    public int MasterItemId { get; set; }

    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    public int Priority { get; set; }

    [StringLength(100)]
    public string GroupMemberDescription { get; set; } = null!;
}
