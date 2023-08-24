using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ReplacementCategory
{
    [Key]
    [Column("ReplacementCategoryID")]
    public int ReplacementCategoryId { get; set; }

    [StringLength(100)]
    public string ReplacementCategoryDescription { get; set; } = null!;

    public bool Enabled { get; set; }
}
