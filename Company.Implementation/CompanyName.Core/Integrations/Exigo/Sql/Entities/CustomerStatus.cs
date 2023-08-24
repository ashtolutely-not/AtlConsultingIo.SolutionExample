using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CustomerStatus
{
    [Key]
    [Column("CustomerStatusID")]
    public int CustomerStatusId { get; set; }

    [StringLength(50)]
    public string CustomerStatusDescription { get; set; } = null!;
}
