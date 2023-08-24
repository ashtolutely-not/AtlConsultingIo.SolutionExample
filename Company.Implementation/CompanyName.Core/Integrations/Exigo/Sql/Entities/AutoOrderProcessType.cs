using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class AutoOrderProcessType
{
    [Key]
    [Column("AutoOrderProcessTypeID")]
    public int AutoOrderProcessTypeId { get; set; }

    [StringLength(50)]
    public string AutoOrderProcessTypeDescription { get; set; } = null!;
}
