using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CreatedDate", Name = "IX_CrDt_Inc")]
[Index("CustomerId", Name = "IX_CustomerID")]
[Index("ModifiedDate", Name = "IX_MoDt_Inc")]
[Index("PayoutTypeId", "PayoutId", Name = "IX_PyoTyId_INC")]
public partial class Payout
{
    [Key]
    [Column("PayoutID")]
    public int PayoutId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PayoutDate { get; set; }

    [Column("PayoutTypeID")]
    public int PayoutTypeId { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [StringLength(101)]
    public string? PayeeName { get; set; }

    [StringLength(100)]
    public string PayeeCompany { get; set; } = null!;

    [StringLength(100)]
    public string? PayeeAddress1 { get; set; }

    [StringLength(100)]
    public string? PayeeAddress2 { get; set; }

    [StringLength(50)]
    public string? PayeeCity { get; set; }

    [StringLength(50)]
    public string? PayeeState { get; set; }

    [StringLength(50)]
    public string? PayeeZip { get; set; }

    [StringLength(50)]
    public string? PayeeCountry { get; set; }

    public int? CheckNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? VoidedDate { get; set; }

    public int? DepositNumber { get; set; }

    public bool IsTaxable { get; set; }

    [Column("BankAccountID")]
    public int BankAccountId { get; set; }

    [StringLength(50)]
    public string Reference { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;
}
