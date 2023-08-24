using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class CodingType
{
    [Key]
    [Column("CodingTypeID")]
    public int CodingTypeId { get; set; }

    [StringLength(100)]
    public string? CodingTypeDescription { get; set; }
}
