using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("WebId", "WebCategoryId")]
public partial class WebCategory
{
    [Key]
    [Column("WebID")]
    public int WebId { get; set; }

    [Key]
    [Column("WebCategoryID")]
    public int WebCategoryId { get; set; }

    [Column("ParentID")]
    public int? ParentId { get; set; }

    [StringLength(50)]
    public string WebCategoryDescription { get; set; } = null!;

    public int NestedLevel { get; set; }

    public int SortOrder { get; set; }
}
