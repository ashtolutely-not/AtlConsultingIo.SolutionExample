using System.ComponentModel.DataAnnotations;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Country
{
    [Key]
    [StringLength(2)]
    public string CountryCode { get; set; } = null!;

    [StringLength(50)]
    public string? CountryDescription { get; set; }

    public int Priority { get; set; }
}
