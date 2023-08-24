using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class Rank
{
    [Key]
    [Column("RankID")]
    public int RankId { get; set; }

    [StringLength(50)]
    public string RankDescription { get; set; } = null!;
}
