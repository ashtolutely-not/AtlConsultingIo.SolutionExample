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

public partial class ExpectedRetailPayment
{
    [Key]
    [Column("RetailOrderID")]
    public int RetailOrderId { get; set; }

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
    public string? CreditCardDescription { get; set; }

    [StringLength(50)]
    public string? CreditCardNumber { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CreditCardExpiration { get; set; }

    [StringLength(50)]
    public string? CreditCardAuthorization { get; set; }

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

    [StringLength(20)]
    public string? BillingCountry { get; set; }
}
