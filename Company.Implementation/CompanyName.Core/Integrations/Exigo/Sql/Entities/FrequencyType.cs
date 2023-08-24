using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class FrequencyType
{
    [Key]
    [Column("FrequencyTypeID")]
    public int FrequencyTypeId { get; set; }

    [StringLength(50)]
    public string FrequencyTypeDescription { get; set; } = null!;
}
