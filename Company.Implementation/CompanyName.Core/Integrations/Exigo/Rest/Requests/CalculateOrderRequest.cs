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
public record CalculateOrderRequest : BaseCalculateOrderRequest
{
    public string CurrencyCode { get; init; }
    public int WarehouseID { get; init; }
    public int ShipMethodID { get; init; }
    public int PriceType { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public string County { get; init; }
    public int CustomerID { get; init; }
    public OrderType OrderType { get; init; }
    public int? OrderSubStatusTy { get; init; }
    public Decimal? TaxRateOverride { get; init; }
    public Decimal? ShippingAmountOverride { get; init; }
    public int? ReturnOrderID { get; init; }
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
    public OrderDetailRequest[] Details { get; init; }
    public bool ReturnShipMethods { get; init; }
    public int? PartyID { get; init; }
    public bool ReturnTrace { get; init; }
    public string CustomerKey { get; init; }
    public string ReturnOrderKey { get; init; }
    public int OrderID { get; init; }

    public CalculateOrderRequest() : base()
    {
        CurrencyCode = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        Address3 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        County = String.Empty;
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
        CustomerKey = String.Empty;
        ReturnOrderKey = String.Empty;
    }
}
