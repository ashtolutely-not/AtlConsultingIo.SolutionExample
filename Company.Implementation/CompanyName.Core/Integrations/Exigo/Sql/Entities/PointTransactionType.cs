using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PointTransactionType
{
    [Key]
    [Column("PointTransactionTypeID")]
    public int PointTransactionTypeId { get; set; }

    [StringLength(50)]
    public string PointTransactionTypeDescription { get; set; } = null!;
}
