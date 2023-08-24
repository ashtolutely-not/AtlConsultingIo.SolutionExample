using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class SocialNetwork
{
    [Key]
    [Column("SocialNetworkID")]
    public int SocialNetworkId { get; set; }

    [StringLength(100)]
    public string SocialNetworkDescription { get; set; } = null!;
}
