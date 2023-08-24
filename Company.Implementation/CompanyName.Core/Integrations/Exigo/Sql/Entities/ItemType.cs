using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ItemType
{
    [Key]
    [Column("ItemTypeID")]
    public int ItemTypeId { get; set; }

    [StringLength(50)]
    public string? ItemTypeDescription { get; set; }
}
