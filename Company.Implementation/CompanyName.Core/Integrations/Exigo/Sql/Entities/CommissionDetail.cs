using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[PrimaryKey("CommissionRunId", "CommissionDetailId")]
[Index("CommissionRunId", "CustomerId", Name = "IX_CommRunIDCustID")]
public partial class CommissionDetail
{
    [Key]
    [Column("CommissionRunID")]
    public int CommissionRunId { get; set; }

    [Key]
    [Column("CommissionDetailID")]
    public long CommissionDetailId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("BonusID")]
    public int BonusId { get; set; }

    [Column("FromCustomerID")]
    public int? FromCustomerId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column(TypeName = "money")]
    public decimal SourceAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal Percentage { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionAmount { get; set; }

    public int? Level { get; set; }

    public int? PaidLevel { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(3)]
    public string EntryCurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal EntrySourceAmount { get; set; }

    [Column(TypeName = "money")]
    public decimal EntryCommissionAmount { get; set; }

    [Column("ToRankID")]
    public int? ToRankId { get; set; }

    [Column("FromRankID")]
    public int? FromRankId { get; set; }
}
