using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("WebId", "WebCategoryId", "ItemId")]
public partial class WebCategoryItem
{
    [Key]
    [Column("WebID")]
    public int WebId { get; set; }

    [Key]
    [Column("WebCategoryID")]
    public int WebCategoryId { get; set; }

    [Key]
    [Column("ItemID")]
    public int ItemId { get; set; }

    public int SortOrder { get; set; }
}
