using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ItemDynamicKitCategory
{
    [Key]
    [Column("DynamicKitCategoryID")]
    public int DynamicKitCategoryId { get; set; }

    [StringLength(50)]
    public string DynamicKitCategoryDescription { get; set; } = null!;
}
