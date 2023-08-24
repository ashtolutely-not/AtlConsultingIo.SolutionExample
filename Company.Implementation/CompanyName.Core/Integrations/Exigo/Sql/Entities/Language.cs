using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Language
{
    [Key]
    [Column("LanguageID")]
    public int LanguageId { get; set; }

    [StringLength(50)]
    public string LanguageDescription { get; set; } = null!;
}
