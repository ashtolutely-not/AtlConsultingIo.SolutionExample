// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record OrderResponse
{
    public int OrderID { get; init; }
    public int CustomerID { get; init; }
    public OrderStatusType OrderStatus { get; init; }
    public int? OrderSubStatusTy { get; init; }
    public DateTime OrderDate { get; init; }
    public string CurrencyCode { get; init; }
    public int WarehouseID { get; init; }
    public int ShipMethodID { get; init; }
    public int PriceType { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Company { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public string County { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Notes { get; init; }
    public Decimal Total { get; init; }
    public Decimal SubTotal { get; init; }
    public Decimal TaxTotal { get; init; }
    public Decimal ShippingTotal { get; init; }
    public Decimal DiscountTotal { get; init; }
    public Decimal DiscountPercent { get; init; }
    public Decimal WeightTotal { get; init; }
    public Decimal BusinessVolumeTotal { get; init; }
    public Decimal CommissionableVolumeTotal { get; init; }
    public string TrackingNumber1 { get; init; }
    public string TrackingNumber2 { get; init; }
    public string TrackingNumber3 { get; init; }
    public string TrackingNumber4 { get; init; }
    public string TrackingNumber5 { get; init; }
    public Decimal Other1Total { get; init; }
    public Decimal Other2Total { get; init; }
    public Decimal Other3Total { get; init; }
    public Decimal Other4Total { get; init; }
    public Decimal Other5Total { get; init; }
    public Decimal Other6Total { get; init; }
    public Decimal Other7Total { get; init; }
    public Decimal Other8Total { get; init; }
    public Decimal Other9Total { get; init; }
    public Decimal Other10Total { get; init; }
    public Decimal ShippingTax { get; init; }
    public Decimal OrderTax { get; init; }
    public Decimal FedTaxTotal { get; init; }
    public Decimal StateTaxTotal { get; init; }
    public Decimal FedShippingTax { get; init; }
    public Decimal StateShippingTax { get; init; }
    public Decimal CityShippingTax { get; init; }
    public Decimal CityLocalShippingTax { get; init; }
    public Decimal CountyShippingTax { get; init; }
    public Decimal CountyLocalShippingTax { get; init; }
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
    public DateTime ModifiedDate { get; init; }
    public int OrderTyID { get; init; }
    public DateTime? ShippedDate { get; init; }
    public DateTime CreatedDate { get; init; }
    public string CreatedBy { get; init; }
    public string ModifiedBy { get; init; }
    public Decimal TaxFedRate { get; init; }
    public Decimal TaxStateRate { get; init; }
    public Decimal TaxCityRate { get; init; }
    public Decimal TaxCityLocalRate { get; init; }
    public Decimal TaxCountyRate { get; init; }
    public Decimal TaxCountyLocalRate { get; init; }
    public Decimal TaxManualRate { get; init; }
    public string TaxCity { get; init; }
    public string TaxCounty { get; init; }
    public string TaxState { get; init; }
    public string TaxZip { get; init; }
    public string TaxCountry { get; init; }
    public bool TaxIsExempt { get; init; }
    public bool TaxIsOverRide { get; init; }
    public OrderDetailResponse[] Details { get; init; }
    public PaymentResponse[] Payments { get; init; }
    public ExpectedPaymentResponse[] ExpectedPayments { get; init; }
    public CustomerResponse? Customer { get; init; }
    public string MiddleName { get; init; }
    public string NameSuffix { get; init; }
    public int? AutoOrderID { get; init; }
    public int? PartyID { get; init; }
    public string Reference1 { get; init; }
    public bool IsRMA { get; init; }
    public int? BackOrderFromID { get; init; }
    public int? TransferToID { get; init; }
    public bool SuppressPackSlipPrice { get; init; }
    public int? ReturnOrderID { get; init; }
    public string OrderKey { get; init; }
    public string CustomerKey { get; init; }
    public int? ReplacementOrderID { get; init; }
    public string OrderTyDescription { get; init; }

    public OrderResponse() : base()
    {
        CurrencyCode = String.Empty;
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        Address3 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        County = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        Notes = String.Empty;
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
        CreatedBy = String.Empty;
        ModifiedBy = String.Empty;
        TaxCity = String.Empty;
        TaxCounty = String.Empty;
        TaxState = String.Empty;
        TaxZip = String.Empty;
        TaxCountry = String.Empty;
        Details = new OrderDetailResponse[0];
        Payments = new PaymentResponse[0];
        ExpectedPayments = new ExpectedPaymentResponse[0];
        MiddleName = String.Empty;
        NameSuffix = String.Empty;
        Reference1 = String.Empty;
        OrderKey = String.Empty;
        CustomerKey = String.Empty;
        OrderTyDescription = String.Empty;
    }
}
