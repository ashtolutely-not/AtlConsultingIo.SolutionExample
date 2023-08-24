using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class AutoOrderStatus
{
    [Key]
    [Column("AutoOrderStatusID")]
    public int AutoOrderStatusId { get; set; }

    [StringLength(50)]
    public string AutoOrderStatusDescription { get; set; } = null!;
}
