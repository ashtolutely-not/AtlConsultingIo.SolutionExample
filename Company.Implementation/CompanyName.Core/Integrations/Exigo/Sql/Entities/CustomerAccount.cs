using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyName.Core.Integrations.Exigo.Sql;

[Index("CustomerId", Name = "IX_CustID_Inc")]
public partial class CustomerAccount
{
    [Key]
    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [StringLength(50)]
    public string? PrimaryCreditCardDisplay { get; set; }

    public int? PrimaryExpirationMonth { get; set; }

    public int? PrimaryExpirationYear { get; set; }

    [Column("PrimaryCreditCardTypeID")]
    public int PrimaryCreditCardTypeId { get; set; }

    [StringLength(50)]
    public string PrimaryBillingName { get; set; } = null!;

    [StringLength(100)]
    public string? PrimaryBillingAddress { get; set; }

    [StringLength(100)]
    public string? PrimaryBillingAddress2 { get; set; }

    [StringLength(50)]
    public string? PrimaryBillingCity { get; set; }

    [StringLength(50)]
    public string? PrimaryBillingState { get; set; }

    [StringLength(50)]
    public string? PrimaryBillingZip { get; set; }

    [StringLength(50)]
    public string? PrimaryBillingCountry { get; set; }

    [StringLength(50)]
    public string? SecondaryCreditCardDisplay { get; set; }

    public int? SecondaryExpirationMonth { get; set; }

    public int? SecondaryExpirationYear { get; set; }

    [Column("SecondaryCreditCardTypeID")]
    public int SecondaryCreditCardTypeId { get; set; }

    [StringLength(50)]
    public string SecondaryBillingName { get; set; } = null!;

    [StringLength(100)]
    public string? SecondaryBillingAddress { get; set; }

    [StringLength(100)]
    public string? SecondaryBillingAddress2 { get; set; }

    [StringLength(50)]
    public string? SecondaryBillingCity { get; set; }

    [StringLength(50)]
    public string? SecondaryBillingState { get; set; }

    [StringLength(50)]
    public string? SecondaryBillingZip { get; set; }

    [StringLength(50)]
    public string? SecondaryBillingCountry { get; set; }

    [StringLength(50)]
    public string? BankAccountNumber { get; set; }

    [StringLength(50)]
    public string BankRoutingNumber { get; set; } = null!;

    [StringLength(50)]
    public string BankNameOnAccount { get; set; } = null!;

    [StringLength(100)]
    public string? BankAccountAddress { get; set; }

    [StringLength(50)]
    public string? BankAccountCity { get; set; }

    [StringLength(50)]
    public string? BankAccountState { get; set; }

    [StringLength(50)]
    public string? BankAccountZip { get; set; }

    [StringLength(50)]
    public string? BankAccountCountry { get; set; }

    [StringLength(50)]
    public string DriversLicenseNumber { get; set; } = null!;

    [StringLength(50)]
    public string DepositNameOnAcount { get; set; } = null!;

    [StringLength(50)]
    public string DepositAccountNumber { get; set; } = null!;

    [StringLength(50)]
    public string DepositRoutingNumber { get; set; } = null!;

    [StringLength(50)]
    public string Iban { get; set; } = null!;

    [StringLength(50)]
    public string SwiftCode { get; set; } = null!;

    [StringLength(50)]
    public string CheckIban { get; set; } = null!;

    [StringLength(50)]
    public string CheckSwiftCode { get; set; } = null!;

    [StringLength(100)]
    public string DepositBankName { get; set; } = null!;

    [StringLength(250)]
    public string DepositBankAddress { get; set; } = null!;

    [StringLength(50)]
    public string DepositBankCity { get; set; } = null!;

    [StringLength(50)]
    public string DepositBankState { get; set; } = null!;

    [StringLength(50)]
    public string DepositBankZip { get; set; } = null!;

    [StringLength(50)]
    public string DepositBankCountry { get; set; } = null!;

    [Column("PrimaryWalletTypeID")]
    public int PrimaryWalletTypeId { get; set; }

    public string? PrimaryWalletAccount { get; set; }

    [StringLength(200)]
    public string? PrimaryWalletOther1 { get; set; }

    [StringLength(200)]
    public string? PrimaryWalletOther2 { get; set; }

    [StringLength(200)]
    public string? PrimaryWalletOther3 { get; set; }

    [Column("SecondaryWalletTypeID")]
    public int SecondaryWalletTypeId { get; set; }

    public string? SecondaryWalletAccount { get; set; }

    [StringLength(200)]
    public string? SecondaryWalletOther1 { get; set; }

    [StringLength(200)]
    public string? SecondaryWalletOther2 { get; set; }

    [StringLength(200)]
    public string? SecondaryWalletOther3 { get; set; }

    [Column("TertiaryWalletTypeID")]
    public int TertiaryWalletTypeId { get; set; }

    public string? TertiaryWalletAccount { get; set; }

    [StringLength(200)]
    public string? TertiaryWalletOther1 { get; set; }

    [StringLength(200)]
    public string? TertiaryWalletOther2 { get; set; }

    [StringLength(200)]
    public string? TertiaryWalletOther3 { get; set; }

    [Column("QuaternaryWalletTypeID")]
    public int QuaternaryWalletTypeId { get; set; }

    public string? QuaternaryWalletAccount { get; set; }

    [StringLength(200)]
    public string? QuaternaryWalletOther1 { get; set; }

    [StringLength(200)]
    public string? QuaternaryWalletOther2 { get; set; }

    [StringLength(200)]
    public string? QuaternaryWalletOther3 { get; set; }

    [Column("QuinaryWalletTypeID")]
    public int QuinaryWalletTypeId { get; set; }

    public string? QuinaryWalletAccount { get; set; }

    [StringLength(200)]
    public string? QuinaryWalletOther1 { get; set; }

    [StringLength(200)]
    public string? QuinaryWalletOther2 { get; set; }

    [StringLength(200)]
    public string? QuinaryWalletOther3 { get; set; }

    public int? CreditCardTokenType { get; set; }

    [StringLength(50)]
    public string? CreditCardToken { get; set; }

    public int? CreditCardTokenType2 { get; set; }

    [StringLength(50)]
    public string? CreditCardToken2 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(50)]
    public string ModifiedBy { get; set; } = null!;

    public int BankAccountType { get; set; }
}
