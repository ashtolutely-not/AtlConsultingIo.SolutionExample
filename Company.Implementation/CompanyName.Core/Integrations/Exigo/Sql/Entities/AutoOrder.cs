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

[Index("CustomerId", Name = "IX_AutoOrders_CustomerID")]
[Index("AutoOrderStatusId", "CancelledDate", "CustomerId", "AutoOrderId", "CommissionableVolumeTotal", Name = "_dta_index_AutoOrders_9_1338343474__K3_K9_K2_K1_K37")]
public partial class AutoOrder
{
    [Key]
    [Column("AutoOrderID")]
    public int AutoOrderId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("AutoOrderStatusID")]
    public int AutoOrderStatusId { get; set; }

    [Column("FrequencyTypeID")]
    public int FrequencyTypeId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? StopDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LastRunDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? NextRunDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CancelledDate { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Column("ShipMethodID")]
    public int ShipMethodId { get; set; }

    [Column("AutoOrderPaymentTypeID")]
    public int AutoOrderPaymentTypeId { get; set; }

    [Column("AutoOrderProcessTypeID")]
    public int AutoOrderProcessTypeId { get; set; }

    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [StringLength(50)]
    public string MiddleName { get; set; } = null!;

    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [StringLength(50)]
    public string NameSuffix { get; set; } = null!;

    [StringLength(100)]
    public string Company { get; set; } = null!;

    [StringLength(100)]
    public string Address1 { get; set; } = null!;

    [StringLength(100)]
    public string Address2 { get; set; } = null!;

    [StringLength(100)]
    public string Address3 { get; set; } = null!;

    [StringLength(50)]
    public string City { get; set; } = null!;

    [StringLength(50)]
    public string State { get; set; } = null!;

    [StringLength(50)]
    public string Zip { get; set; } = null!;

    [StringLength(50)]
    public string Country { get; set; } = null!;

    [StringLength(50)]
    public string County { get; set; } = null!;

    [StringLength(200)]
    public string Email { get; set; } = null!;

    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [StringLength(500)]
    public string Notes { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Total { get; set; }

    [Column(TypeName = "money")]
    public decimal SubTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal TaxTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal ShippingTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal DiscountTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolumeTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolumeTotal { get; set; }

    [StringLength(100)]
    public string AutoOrderDescription { get; set; } = null!;

    [StringLength(400)]
    public string? Other11 { get; set; }

    [StringLength(400)]
    public string? Other12 { get; set; }

    [StringLength(400)]
    public string? Other13 { get; set; }

    [StringLength(400)]
    public string? Other14 { get; set; }

    [StringLength(400)]
    public string? Other15 { get; set; }

    [StringLength(400)]
    public string? Other16 { get; set; }

    [StringLength(400)]
    public string? Other17 { get; set; }

    [StringLength(400)]
    public string? Other18 { get; set; }

    [StringLength(400)]
    public string? Other19 { get; set; }

    [StringLength(400)]
    public string? Other20 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;
}
