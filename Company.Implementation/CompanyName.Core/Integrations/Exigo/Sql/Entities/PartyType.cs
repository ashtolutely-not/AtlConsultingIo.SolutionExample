using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PartyType
{
    [Key]
    [Column("PartyTypeID")]
    public int PartyTypeId { get; set; }

    [StringLength(100)]
    public string PartyTypeDescription { get; set; } = null!;
}
