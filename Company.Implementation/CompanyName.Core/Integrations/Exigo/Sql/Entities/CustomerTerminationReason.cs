using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerTerminationReason
{
    [Key]
    [Column("ReasonID")]
    public int ReasonId { get; set; }

    [StringLength(256)]
    public string Reason { get; set; } = null!;
}
