using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CompanyNews
{
    [Key]
    [Column("CompanyNewsID")]
    public int CompanyNewsId { get; set; }

    [StringLength(1000)]
    public string? Title { get; set; }

    public string Content { get; set; } = null!;

    public bool IsCompanyWide { get; set; }

    public bool AvailableOnWeb { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }
}
