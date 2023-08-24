using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class BillType
{
    [Key]
    [Column("BillTypeID")]
    public int BillTypeId { get; set; }

    [StringLength(50)]
    public string BillTypeDescription { get; set; } = null!;
}
