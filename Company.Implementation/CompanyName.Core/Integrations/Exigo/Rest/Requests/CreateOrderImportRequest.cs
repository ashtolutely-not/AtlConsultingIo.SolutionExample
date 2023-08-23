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
public record CreateOrderImportRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Company { get; init; }
    public string Phone { get; init; }
    public string Email { get; init; }
    public int ShipMethodID { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public string County { get; init; }
    public string Notes { get; init; }
    public int WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public Decimal ShippingStateTax { get; init; }
    public Decimal ShippingFedTax { get; init; }
    public Decimal ShippingCountyLocalTax { get; init; }
    public Decimal ShippingCountyTax { get; init; }
    public Decimal ShippingCityLocalTax { get; init; }
    public Decimal ShippingCityTax { get; init; }
    public Decimal Shipping { get; init; }
    public int PriceType { get; init; }
    public OrderStatusType OrderStatus { get; init; }
    public DateTime OrderDate { get; init; }
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
    public OrderType OrderType { get; init; }
    public bool? UseManualOrderID { get; init; }
    public int? ManualOrderID { get; init; }
    public int? ReturnOrderID { get; init; }
    public OrderImportDetail[] OrderDetails { get; init; }
    public int? PartyID { get; init; }
    public string ManualOrderKey { get; init; }
    public string ReturnOrderKey { get; init; }
    public string CustomerKey { get; init; }
    public bool OverwriteExistingOrder { get; init; }
    public int? ExistingOrderID { get; init; }
    public string ExistingOrderKey { get; init; }
    public bool IsCommissionable { get; init; }
    public Decimal? HandlingFee { get; init; }

    public CreateOrderImportRequest() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Phone = String.Empty;
        Email = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        Address3 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        County = String.Empty;
        Notes = String.Empty;
        CurrencyCode = String.Empty;
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
        OrderDetails = new OrderImportDetail[0];
        ManualOrderKey = String.Empty;
        ReturnOrderKey = String.Empty;
        CustomerKey = String.Empty;
        ExistingOrderKey = String.Empty;
    }
}
