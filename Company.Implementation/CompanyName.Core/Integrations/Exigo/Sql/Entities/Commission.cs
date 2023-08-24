using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CustomerId")]
[Index("CustomerId", Name = "IX_CustID")]
[Index("Earnings", Name = "NonClusteredIndex-20200814-190823")]
public partial class Commission
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Earnings { get; set; }

    [Column(TypeName = "money")]
    public decimal PreviousBalance { get; set; }

    [Column(TypeName = "money")]
    public decimal BalanceForward { get; set; }

    [Column(TypeName = "money")]
    public decimal Fee { get; set; }

    [Column(TypeName = "money")]
    public decimal Total { get; set; }
}
