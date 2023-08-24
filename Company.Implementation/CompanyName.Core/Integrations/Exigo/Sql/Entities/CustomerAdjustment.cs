using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_CustomerAdjustments_CustomerID")]
public partial class CustomerAdjustment
{
    [Key]
    [Column("TransactionID")]
    public int TransactionId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("CustomerTransactionTypeID")]
    public int CustomerTransactionTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime TransactionDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;

    [StringLength(50)]
    public string Notes { get; set; } = null!;
}
