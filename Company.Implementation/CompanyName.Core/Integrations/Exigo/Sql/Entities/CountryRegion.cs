using System.ComponentModel.DataAnnotations;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CountryCode", "RegionCode")]
public partial class CountryRegion
{
    [Key]
    [StringLength(2)]
    public string CountryCode { get; set; } = null!;

    [Key]
    [StringLength(50)]
    public string RegionCode { get; set; } = null!;

    [StringLength(50)]
    public string? RegionDescription { get; set; }
}
