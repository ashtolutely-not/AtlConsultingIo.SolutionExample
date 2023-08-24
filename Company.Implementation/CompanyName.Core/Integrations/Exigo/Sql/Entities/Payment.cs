using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("ModifiedDate", Name = "IX_ModDt_Inc")]
[Index("OrderId", Name = "IX_OID_Inc_Amount")]
[Index("PaymentTypeId", "ModifiedDate", Name = "IX_PayTyIdModDt_Inc")]
[Index("OrderId", Name = "IX_Payments_OrderID")]
public partial class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column("PaymentTypeID")]
    public int PaymentTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [StringLength(50)]
    public string? BillingName { get; set; }

    [Column("CreditCardTypeID")]
    public int CreditCardTypeId { get; set; }

    [StringLength(50)]
    public string? CreditCardNumber { get; set; }

    [StringLength(50)]
    public string? AuthorizationCode { get; set; }

    [StringLength(50)]
    public string? CheckNumber { get; set; }

    [StringLength(50)]
    public string? CheckAccountNumber { get; set; }

    [StringLength(50)]
    public string? CheckRoutingNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckDate { get; set; }

    [StringLength(100)]
    public string? CheckBankName { get; set; }

    [StringLength(100)]
    public string? CheckBankAddress { get; set; }

    [StringLength(50)]
    public string? CheckBankCityAddress { get; set; }

    [StringLength(50)]
    public string? CheckBankStateAddress { get; set; }

    [StringLength(50)]
    public string? CheckBankZipAddress { get; set; }

    [StringLength(500)]
    public string? Memo { get; set; }

    [Column("WalletTypeID")]
    public int? WalletTypeId { get; set; }

    [StringLength(50)]
    public string? DriversLicenseNumber { get; set; }

    [Column("MerchantTypeID")]
    public int? MerchantTypeId { get; set; }

    [StringLength(300)]
    public string? MerchantTransactionKey { get; set; }

    [Column("PointAccountID")]
    public int? PointAccountId { get; set; }

    [StringLength(100)]
    public string? BillingAddress1 { get; set; }

    [StringLength(100)]
    public string? BillingAddress2 { get; set; }

    [StringLength(50)]
    public string? BillingCity { get; set; }

    [StringLength(50)]
    public string? BillingState { get; set; }

    [StringLength(50)]
    public string? BillingZipAddress { get; set; }

    [StringLength(50)]
    public string? BillingCountry { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
