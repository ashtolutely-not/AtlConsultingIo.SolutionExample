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
public record GetOrdersRequest : ApiRequest
{
    public int? CustomerID { get; init; }
    public int? OrderID { get; init; }
    public int[] OrderIDs { get; init; }
    public DateTime? OrderDateStart { get; init; }
    public DateTime? OrderDateEnd { get; init; }
    public OrderStatusType? OrderStatus { get; init; }
    public OrderStatusType[] OtherOrderStatuses { get; init; }
    public int[] OrderTys { get; init; }
    public int? WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public bool? ReturnCustomer { get; init; }
    public bool? ReturnKitDetails { get; init; }
    public int? GreaterThanOrderID { get; init; }
    public DateTime? GreaterThanModifiedDate { get; init; }
    public int? BatchSize { get; init; }
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
    public int? PartyID { get; init; }
    public string CustomerKey { get; init; }
    public string OrderKey { get; init; }
    public string[] OrderKeys { get; init; }

    public GetOrdersRequest() : base()
    {
        OrderIDs = new int[0];
        OtherOrderStatuses = new OrderStatusType[0];
        OrderTys = new int[0];
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
        CustomerKey = String.Empty;
        OrderKey = String.Empty;
        OrderKeys = new string[0];
    }
}
