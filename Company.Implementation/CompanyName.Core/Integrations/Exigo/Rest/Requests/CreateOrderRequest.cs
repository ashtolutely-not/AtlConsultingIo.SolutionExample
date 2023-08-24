// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateOrderRequest : BaseCalculateOrderRequest, ITransactionMember
{
    public int CustomerID { get; set; }
    public OrderStatusType OrderStatus { get; set; }
    public DateTime OrderDate { get; set; }
    public string CurrencyCode { get; set; }
    public int WarehouseID { get; set; }
    public int ShipMethodID { get; set; }
    public int PriceType { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string NameSuffix { get; set; }
    public string Company { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string Address3 { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string Country { get; set; }
    public string County { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Notes { get; set; }
    public string Other11 { get; set; }
    public string Other12 { get; set; }
    public string Other13 { get; set; }
    public string Other14 { get; set; }
    public string Other15 { get; set; }
    public string Other16 { get; set; }
    public string Other17 { get; set; }
    public string Other18 { get; set; }
    public string Other19 { get; set; }
    public string Other20 { get; set; }
    public OrderType OrderType { get; set; }
    public Decimal? TaxRateOverride { get; set; }
    public Decimal? ShippingAmountOverride { get; set; }
    public bool? UseManualOrderID { get; set; }
    public int? ManualOrderID { get; set; }
    public int? TransferVolumeToID { get; set; }
    public int? ReturnOrderID { get; set; }
    public bool OverwriteExistingOrder { get; set; }
    public int ExistingOrderID { get; set; }
    public int? PartyID { get; set; }
    public OrderDetailRequest[] Details { get; set; }
    public bool SuppressPackSlipPrice { get; set; }
    public string TransferVolumeToKey { get; set; }
    public string ReturnOrderKey { get; set; }
    public string ManualOrderKey { get; set; }
    public string ExistingOrderKey { get; set; }
    public string CustomerKey { get; set; }
    public int? OrderSubStatusTy { get; set; }

    public CreateOrderRequest() : base()
    {
        CurrencyCode = String.Empty;
        FirstName = String.Empty;
        MiddleName = String.Empty;
        LastName = String.Empty;
        NameSuffix = String.Empty;
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
        Details = new OrderDetailRequest[0];
        TransferVolumeToKey = String.Empty;
        ReturnOrderKey = String.Empty;
        ManualOrderKey = String.Empty;
        ExistingOrderKey = String.Empty;
        CustomerKey = String.Empty;
    }
}
