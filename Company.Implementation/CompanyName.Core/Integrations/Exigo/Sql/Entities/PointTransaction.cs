using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_PointTransactions_CustomerID")]
[Index("Reference", "CustomerId", Name = "IX_Reference_Inc_CustID")]
public partial class PointTransaction
{
    [Key]
    [Column("PointTransactionID")]
    public int PointTransactionId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("PointAccountID")]
    public int PointAccountId { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [Column("PointTransactionTypeID")]
    public int PointTransactionTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [StringLength(100)]
    public string Reference { get; set; } = null!;

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;
}
