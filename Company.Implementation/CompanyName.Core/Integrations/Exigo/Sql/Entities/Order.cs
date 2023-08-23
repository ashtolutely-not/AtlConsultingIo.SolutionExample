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

[Index("BatchId", "ShipMethodId", Name = "IX_BatchID_ShipMethodID_Inc_CID")]
[Index("CustomerId", "OrderStatusId", "CreatedDate", Name = "IX_CustID_StatusID_CDate_Inc_BVTotal")]
[Index("ModifiedDate", "OrderTypeId", Name = "IX_ModDt_OrdTpID_INC")]
[Index("OrderDate", "OrderTypeId", "OrderStatusId", Name = "IX_ODate_TypeID_StatusID_Inc")]
[Index("OrderDate", "OrderStatusId", "OrderTypeId", "CustomerId", Name = "IX_OrdDtOrdStidOrdTYCustid", IsDescending = new[] { true, false, false, false })]
[Index("OrderId", "CustomerId", "OrderStatusId", "OrderDate", "Country", Name = "IX_OrderIDCustIDOrderStatusIDOrderDtCountry")]
[Index("OrderStatusId", "CreatedDate", Name = "IX_OrderStatusIDCreatedDt")]
[Index("OrderStatusId", "OrderTypeId", "CreatedDate", Name = "IX_OrderStatusIDOrderTypeIDCreatedDt")]
[Index("ReturnOrderId", "OrderTypeId", Name = "IX_OrderTypeID_INC")]
[Index("OrderStatusId", "OrderDate", "WarehouseId", "OrderTypeId", "CommissionableVolumeTotal", Name = "IX_Orders_CommissionableVolumeTotal")]
[Index("CurrencyCode", Name = "IX_Orders_CurrencyCode")]
[Index("CustomerId", Name = "IX_Orders_CustomerID")]
[Index("OrderId", "OrderStatusId", "OrderTypeId", Name = "IX_Orders_ID_Type_Status")]
[Index("OrderDate", Name = "IX_Orders_OrderDate")]
[Index("OrderStatusId", Name = "IX_Orders_OrderStatusID")]
[Index("PartyId", Name = "IX_Orders_PartyID")]
[Index("ReturnOrderId", Name = "IX_Orders_ReturnOrderID")]
[Index("WarehouseId", Name = "IX_Orders_WarehouseID")]
[Index("OrderStatusId", "BatchId", "Country", Name = "IX_StatusID_BatchID_Country_Inc")]
[Index("TrackingNumber1", "OrderDate", Name = "IX_TrackingNum1OrderID")]
[Index("CustomerId", "OrderDate", "OrderId", "Country", "OrderTypeId", "OrderStatusId", Name = "_dta_index_Orders_5_2065849690__K2_K4_K1_K21_K8_K3")]
[Index("CustomerId", "OrderStatusId", "OrderTypeId", "CommissionableVolumeTotal", Name = "_dta_index_Orders_9_1645912081__K2_K3_K8_K34_4")]
public partial class Order
{
    [Key]
    [Column("OrderID")]
    public int OrderId { get; set; }

    [Column("CustomerID")]
    public int CustomerId { get; set; }

    [Column("OrderStatusID")]
    public int OrderStatusId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime OrderDate { get; set; }

    [StringLength(3)]
    public string CurrencyCode { get; set; } = null!;

    [Column("WarehouseID")]
    public int WarehouseId { get; set; }

    [Column("ShipMethodID")]
    public int ShipMethodId { get; set; }

    [Column("OrderTypeID")]
    public int OrderTypeId { get; set; }

    [Column("PriceTypeID")]
    public int PriceTypeId { get; set; }

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
    public decimal DiscountPercent { get; set; }

    [Column(TypeName = "money")]
    public decimal WeightTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal BusinessVolumeTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal CommissionableVolumeTotal { get; set; }

    [StringLength(50)]
    public string TrackingNumber1 { get; set; } = null!;

    [StringLength(50)]
    public string TrackingNumber2 { get; set; } = null!;

    [StringLength(50)]
    public string TrackingNumber3 { get; set; } = null!;

    [StringLength(50)]
    public string TrackingNumber4 { get; set; } = null!;

    [StringLength(50)]
    public string TrackingNumber5 { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal Other1Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other2Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other3Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other4Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other5Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other6Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other7Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other8Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other9Total { get; set; }

    [Column(TypeName = "money")]
    public decimal Other10Total { get; set; }

    [Column(TypeName = "money")]
    public decimal ShippingTax { get; set; }

    [Column(TypeName = "money")]
    public decimal OrderTax { get; set; }

    [Column(TypeName = "money")]
    public decimal FedTaxTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal StateTaxTotal { get; set; }

    [Column(TypeName = "money")]
    public decimal FedShippingTax { get; set; }

    [Column(TypeName = "money")]
    public decimal StateShippingTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CityShippingTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CityLocalShippingTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CountyShippingTax { get; set; }

    [Column(TypeName = "money")]
    public decimal CountyLocalShippingTax { get; set; }

    [StringLength(200)]
    public string? Other11 { get; set; }

    [StringLength(200)]
    public string? Other12 { get; set; }

    [StringLength(200)]
    public string? Other13 { get; set; }

    [StringLength(200)]
    public string? Other14 { get; set; }

    [StringLength(200)]
    public string? Other15 { get; set; }

    [StringLength(200)]
    public string? Other16 { get; set; }

    [StringLength(200)]
    public string? Other17 { get; set; }

    [StringLength(200)]
    public string? Other18 { get; set; }

    [StringLength(200)]
    public string? Other19 { get; set; }

    [StringLength(200)]
    public string? Other20 { get; set; }

    public bool IsCommissionable { get; set; }

    [Column("AutoOrderID")]
    public int? AutoOrderId { get; set; }

    [Column("ReturnOrderID")]
    public int? ReturnOrderId { get; set; }

    [Column("ReplacementOrderID")]
    public int? ReplacementOrderId { get; set; }

    [Column("ParentOrderID")]
    public int? ParentOrderId { get; set; }

    [Column("BatchID")]
    public int BatchId { get; set; }

    public int DeclineCount { get; set; }

    [Column("TransferToCustomerID")]
    public int? TransferToCustomerId { get; set; }

    [Column("PartyID")]
    public int? PartyId { get; set; }

    [Column("WebCarrierID1")]
    public int? WebCarrierId1 { get; set; }

    [Column("WebCarrierID2")]
    public int? WebCarrierId2 { get; set; }

    [Column("WebCarrierID3")]
    public int? WebCarrierId3 { get; set; }

    [Column("WebCarrierID4")]
    public int? WebCarrierId4 { get; set; }

    [Column("WebCarrierID5")]
    public int? WebCarrierId5 { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ShippedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? LockedDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime ModifiedDate { get; set; }

    [StringLength(30)]
    public string CreatedBy { get; set; } = null!;

    [StringLength(30)]
    public string ModifiedBy { get; set; } = null!;

    public bool SuppressPackSlipPrice { get; set; }

    [Column("ReturnCategoryID")]
    public int? ReturnCategoryId { get; set; }

    [Column("ReplacementCategoryID")]
    public int? ReplacementCategoryId { get; set; }

    [Column("IsRMA")]
    public bool IsRma { get; set; }

    [StringLength(200)]
    public string? TaxIntegrationCalculate { get; set; }

    [StringLength(200)]
    public string? TaxIntegrationCommit { get; set; }

    [Column(TypeName = "money")]
    public decimal HandlingFee { get; set; }

    [StringLength(100)]
    public string PickupName { get; set; } = null!;

    [Column(TypeName = "money")]
    public decimal TotalTaxable { get; set; }

    [Column("OrderSubStatusID")]
    public int? OrderSubStatusId { get; set; }

    [StringLength(50)]
    public string? OrderKey { get; set; }

    public int? ReferralId { get; set; }
}
