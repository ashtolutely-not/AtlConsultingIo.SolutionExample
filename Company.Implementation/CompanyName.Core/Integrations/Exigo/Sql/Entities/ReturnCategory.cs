using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ReturnCategory
{
    [Key]
    [Column("ReturnCategoryID")]
    public int ReturnCategoryId { get; set; }

    [StringLength(100)]
    public string ReturnCategoryDescription { get; set; } = null!;

    public bool Enabled { get; set; }
}
