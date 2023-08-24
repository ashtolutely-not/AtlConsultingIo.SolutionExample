using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class PointAccount
{
    [Key]
    [Column("PointAccountID")]
    public int PointAccountId { get; set; }

    [StringLength(50)]
    public string PointAccountDescription { get; set; } = null!;

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    public bool? CanPayForOrders { get; set; }

    public bool? LimitPaymentToSubTotal { get; set; }
}
