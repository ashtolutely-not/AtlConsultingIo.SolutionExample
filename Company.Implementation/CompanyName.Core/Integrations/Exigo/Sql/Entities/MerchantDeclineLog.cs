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

[Table("MerchantDeclineLog")]
[Index("CustomerId", "OrderId", Name = "IX_NonClustered_CustOrder")]
[Index("OrderId", "MerchantDeclineLogId", Name = "IX_OID_MDeclineLogID_Inc_Message", IsDescending = new[] { false, true })]
public partial class MerchantDeclineLog
{
    [Key]
    [Column("MerchantDeclineLogID")]
    public int MerchantDeclineLogId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntryDate { get; set; }

    [Column("MerchantDeclineReasonID")]
    public int MerchantDeclineReasonId { get; set; }

    [StringLength(500)]
    public string Message { get; set; } = null!;

    [Column("MerchantTypeID")]
    public int MerchantTypeId { get; set; }

    [Column(TypeName = "money")]
    public decimal Amount { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("OrderID")]
    public int OrderId { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [StringLength(50)]
    public string? CreditCardDisplay { get; set; }

    public bool? PassedCvvCode { get; set; }

    public int? ExpirationMonth { get; set; }

    public int? ExpirationYear { get; set; }

    [StringLength(100)]
    public string? BillingName { get; set; }

    [StringLength(100)]
    public string? BillingAddress { get; set; }

    [StringLength(50)]
    public string? BillingCity { get; set; }

    [StringLength(50)]
    public string? BillingState { get; set; }

    [StringLength(50)]
    public string? BillingZip { get; set; }

    [StringLength(50)]
    public string? BillingCountry { get; set; }

    public string? AdditionalReturnData { get; set; }
}
