// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record UpdateOrderRequest : ApiRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public DateTime? OrderDate { get; init; }
    public int? DeclineCount { get; init; }
    public int? OrderTy { get; init; }
    public int? OrderStatus { get; init; }
    public int? OrderSubStatusTy { get; init; }
    public int? PriceTy { get; init; }
    public Decimal? Total { get; init; }
    public Decimal? SubTotal { get; init; }
    public Decimal? Shipping { get; init; }
    public Decimal? OrderTax { get; init; }
    public Decimal? ShippingTax { get; init; }
    public Decimal? FedShippingTax { get; init; }
    public Decimal? StateShippingTax { get; init; }
    public Decimal? CityShippingTax { get; init; }
    public Decimal? CityLocalShippingTax { get; init; }
    public Decimal? CountyShippingTax { get; init; }
    public Decimal? CountyLocalShippingTax { get; init; }
    public Decimal? ManualTaxRate { get; init; }
    public Decimal? TotalTax { get; init; }
    public string CurrencyCode { get; init; }
    public int? PaymentMethod { get; init; }
    public int? WarehouseID { get; init; }
    public int? BatchID { get; init; }
    public Decimal? PreviousBalance { get; init; }
    public bool? OverrideShipping { get; init; }
    public bool? OverrideTax { get; init; }
    public Decimal? BusinessVolume { get; init; }
    public Decimal? CommissionableVolume { get; init; }
    public Decimal? Other1 { get; init; }
    public Decimal? Other2 { get; init; }
    public Decimal? Other3 { get; init; }
    public Decimal? Other4 { get; init; }
    public Decimal? Other5 { get; init; }
    public Decimal? Discount { get; init; }
    public Decimal? DiscountPercent { get; init; }
    public Decimal? Weight { get; init; }
    public int? Sourcety { get; init; }
    public string Notes { get; init; }
    public string Usr { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Company { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public bool? SuppressPackSlipPrice { get; init; }
    public int? ShipMethodID { get; init; }
    public int? AutoOrderID { get; init; }
    public string CreatedBy { get; init; }
    public int? ReturnOrderID { get; init; }
    public int? OrderRankID { get; init; }
    public int? OrderPayRankID { get; init; }
    public bool? AddressIsVerified { get; init; }
    public string County { get; init; }
    public bool? IsRMA { get; init; }
    public int? BackOrderFromID { get; init; }
    public Decimal? CreditsEarned { get; init; }
    public Decimal? TotalFedTax { get; init; }
    public Decimal? TotalStateTax { get; init; }
    public Decimal? ManualShippingTax { get; init; }
    public int? ReplacementOrderID { get; init; }
    public DateTime? LockedDate { get; init; }
    public DateTime? CommissionedDate { get; init; }
    public bool? Flag1 { get; init; }
    public bool? Flag2 { get; init; }
    public bool? Flag3 { get; init; }
    public Decimal? Other6 { get; init; }
    public Decimal? Other7 { get; init; }
    public Decimal? Other8 { get; init; }
    public Decimal? Other9 { get; init; }
    public Decimal? Other10 { get; init; }
    public int? OriginalWarehouseID { get; init; }
    public string PickupName { get; init; }
    public int? TransferToID { get; init; }
    public bool? IsCommissionable { get; init; }
    public string FulfilledBy { get; init; }
    public Decimal? CreditApplied { get; init; }
    public DateTime? ShippedDate { get; init; }
    public DateTime? TaxLockDate { get; init; }
    public Decimal? TotalTaxable { get; init; }
    public int? ReturnCategoryID { get; init; }
    public int? ReplacementCategoryID { get; init; }
    public Decimal? CalculatedShipping { get; init; }
    public Decimal? HandlingFee { get; init; }
    public int? OrderProcessTy { get; init; }
    public int? ActualCarrier { get; init; }
    public int? ParentOrderID { get; init; }
    public int? CustomerTy { get; init; }
    public string Reference { get; init; }
    public string MiddleName { get; init; }
    public string NameSuffix { get; init; }
    public string Address3 { get; init; }
    public int? PartyID { get; init; }
    public string TrackingNumber1 { get; init; }
    public string TrackingNumber2 { get; init; }
    public string TrackingNumber3 { get; init; }
    public string TrackingNumber4 { get; init; }
    public string TrackingNumber5 { get; init; }
    public OrderShipCarrier? WebCarrierID { get; init; }
    public OrderShipCarrier? WebCarrierID2 { get; init; }
    public OrderShipCarrier? WebCarrierID3 { get; init; }
    public OrderShipCarrier? WebCarrierID4 { get; init; }
    public OrderShipCarrier? WebCarrierID5 { get; init; }
    public string Other11 { get; init; }
    public string Other12 { get; init; }
    public string Other13 { get; init; }
    public string Other14 { get; init; }
    public string Other15 { get; init; }
    public string Other16 { get; init; }
    public string Other17 { get; init; }
    public string Other18 { get; init; }
    public string Other19 { get; init; }
    public string Other20 { get; init; }
    public string TransferToKey { get; init; }
    public string OrderKey { get; init; }
    public string ReturnOrderKey { get; init; }
    public string ReplacementOrderKey { get; init; }
    public string ParentOrderKey { get; init; }
    public string BackOrderFromKey { get; init; }

    public UpdateOrderRequest() : base()
    {
        CurrencyCode = String.Empty;
        Notes = String.Empty;
        Usr = String.Empty;
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        CreatedBy = String.Empty;
        County = String.Empty;
        PickupName = String.Empty;
        FulfilledBy = String.Empty;
        Reference = String.Empty;
        MiddleName = String.Empty;
        NameSuffix = String.Empty;
        Address3 = String.Empty;
        TrackingNumber1 = String.Empty;
        TrackingNumber2 = String.Empty;
        TrackingNumber3 = String.Empty;
        TrackingNumber4 = String.Empty;
        TrackingNumber5 = String.Empty;
        Other11 = String.Empty;
        Other12 = String.Empty;
        Other13 = String.Empty;
        Other14 = String.Empty;
        Other15 = String.Empty;
        Other16 = String.Empty;
        Other17 = String.Empty;
        Other18 = String.Empty;
        Other19 = String.Empty;
        Other20 = String.Empty;
        TransferToKey = String.Empty;
        OrderKey = String.Empty;
        ReturnOrderKey = String.Empty;
        ReplacementOrderKey = String.Empty;
        ParentOrderKey = String.Empty;
        BackOrderFromKey = String.Empty;
    }
}
