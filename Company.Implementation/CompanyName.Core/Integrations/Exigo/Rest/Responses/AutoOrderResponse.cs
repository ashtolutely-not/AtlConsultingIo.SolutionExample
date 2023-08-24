// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AutoOrderResponse
{
    public int CustomerID { get; init; }
    public int AutoOrderID { get; init; }
    public AutoOrderStatusType AutoOrderStatus { get; init; }
    public FrequencyType Frequency { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime? StopDate { get; init; }
    public DateTime LastRunDate { get; init; }
    public DateTime NextRunDate { get; init; }
    public string CurrencyCode { get; init; }
    public int WarehouseID { get; init; }
    public int ShipMethodID { get; init; }
    public AutoOrderPaymentType PaymentType { get; init; }
    public AutoOrderProcessType ProcessType { get; init; }
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
    public Decimal BusinessVolumeTotal { get; init; }
    public Decimal CommissionableVolumeTotal { get; init; }
    public string Description { get; init; }
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
    public AutoOrderDetailResponse[] Details { get; init; }
    public DateTime ModifiedDate { get; init; }
    public string ModifiedBy { get; init; }
    public string MiddleName { get; init; }
    public string NameSuffix { get; init; }
    public int? SpecificDayInterval { get; init; }
    public DateTime CreatedDate { get; init; }
    public string CreatedBy { get; init; }
    public string CustomerKey { get; init; }
    public int? CustomFrequencyTy { get; init; }

    public AutoOrderResponse() : base()
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
        Description = String.Empty;
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
        Details = new AutoOrderDetailResponse[0];
        ModifiedBy = String.Empty;
        MiddleName = String.Empty;
        NameSuffix = String.Empty;
        CreatedBy = String.Empty;
        CustomerKey = String.Empty;
    }
}
