using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PayableType
{
    [Key]
    [Column("PayableTypeID")]
    public int PayableTypeId { get; set; }

    [StringLength(50)]
    public string? PayableTypeDescription { get; set; }
}
