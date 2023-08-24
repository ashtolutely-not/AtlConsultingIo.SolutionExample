using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class OrderType
{
    [Key]
    [Column("OrderTypeID")]
    public int OrderTypeId { get; set; }

    [StringLength(50)]
    public string OrderTypeDescription { get; set; } = null!;
}
