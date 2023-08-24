using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class OrderSubStatusType
{
    [Key]
    [Column("OrderSubStatusID")]
    public int OrderSubStatusId { get; set; }

    [StringLength(100)]
    public string Description { get; set; } = null!;

    public bool? IsDeleted { get; set; }
}
