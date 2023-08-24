using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class BillStatus
{
    [Key]
    [Column("BillStatusID")]
    public int BillStatusId { get; set; }

    [StringLength(20)]
    public string BillStatusDescription { get; set; } = null!;
}
