using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PartyStatus
{
    [Key]
    [Column("PartyStatusID")]
    public int PartyStatusId { get; set; }

    [StringLength(100)]
    public string PartyStatusDescription { get; set; } = null!;
}
