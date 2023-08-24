using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Table("Company")]
public partial class Company
{
    [Key]
    [StringLength(15)]
    public string CompanyKey { get; set; } = null!;

    [StringLength(50)]
    public string Name { get; set; } = null!;
}
