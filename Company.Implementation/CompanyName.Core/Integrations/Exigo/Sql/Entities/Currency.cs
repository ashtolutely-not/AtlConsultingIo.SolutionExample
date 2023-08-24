using System.ComponentModel.DataAnnotations;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Currency
{
    [Key]
    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(50)]
    public string? CurrencyDescription { get; set; }

    [StringLength(10)]
    public string? CurrencySymbol { get; set; }
}
