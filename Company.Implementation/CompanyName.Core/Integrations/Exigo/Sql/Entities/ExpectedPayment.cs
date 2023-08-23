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

namespace CompanyName.Core.Integrations.Exigo.Sql;

public partial class ExpectedPayment
{
    [Key]
    [Column("ExpectedPaymentID")]
    public int ExpectedPaymentId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    public int PaymentType { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PaymentDate { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(50)]
    public string? CreditNumber { get; set; }

    [StringLength(10)]
    public string? CreditIssue { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreditExpiration { get; set; }

    [StringLength(50)]
    public string? CreditAuthorization { get; set; }

    [StringLength(50)]
    public string? CheckNumber { get; set; }

    [StringLength(50)]
    public string? CheckAccountNumber { get; set; }

    [StringLength(50)]
    public string? CheckRoutingNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckDate { get; set; }

    [StringLength(50)]
    public string? BillingName { get; set; }

    [StringLength(50)]
    public string? BillingAddress1 { get; set; }

    [StringLength(50)]
    public string? BillingAddress2 { get; set; }

    [StringLength(40)]
    public string? BillingCity { get; set; }

    [StringLength(10)]
    public string? BillingState { get; set; }

    [StringLength(20)]
    public string? BillingZip { get; set; }

    [StringLength(2)]
    public string? BillingCountry { get; set; }

    [StringLength(50)]
    public string? BankName { get; set; }

    [StringLength(200)]
    public string? BankAddress { get; set; }

    [StringLength(40)]
    public string? BankCity { get; set; }

    [StringLength(10)]
    public string? BankState { get; set; }

    [StringLength(20)]
    public string? BankZip { get; set; }

    public int ExpectedPaymentStatusTy { get; set; }

    [StringLength(500)]
    public string? Memo { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }
}
