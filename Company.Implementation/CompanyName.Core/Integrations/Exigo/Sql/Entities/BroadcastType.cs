using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class BroadcastType
{
    [Key]
    [Column("BroadcastTypeID")]
    public int BroadcastTypeId { get; set; }

    [StringLength(50)]
    public string BroadcastTypeDescription { get; set; } = null!;
}
