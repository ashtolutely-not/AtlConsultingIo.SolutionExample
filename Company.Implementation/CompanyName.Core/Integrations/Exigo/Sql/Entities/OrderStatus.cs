using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class OrderStatus
{
    [Key]
    [Column("OrderStatusID")]
    public int OrderStatusId { get; set; }

    [StringLength(50)]
    public string? OrderStatusDescription { get; set; }
}
