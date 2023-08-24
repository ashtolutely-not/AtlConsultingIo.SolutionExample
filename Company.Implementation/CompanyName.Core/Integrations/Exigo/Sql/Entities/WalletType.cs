using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class WalletType
{
    [Key]
    [Column("WalletTypeID")]
    public int WalletTypeId { get; set; }

    [StringLength(50)]
    public string WalletTypeDescription { get; set; } = null!;
}
