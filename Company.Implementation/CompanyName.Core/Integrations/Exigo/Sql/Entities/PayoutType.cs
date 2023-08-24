using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PayoutType
{
    [Key]
    [Column("PayoutTypeID")]
    public int PayoutTypeId { get; set; }

    [StringLength(50)]
    public string PayoutDescription { get; set; } = null!;
}
