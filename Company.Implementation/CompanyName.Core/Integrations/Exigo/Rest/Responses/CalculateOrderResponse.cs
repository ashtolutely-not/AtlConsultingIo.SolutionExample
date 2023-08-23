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
public record CalculateOrderResponse : BaseCalculateOrderResponse
{
    public Decimal Total { get; init; }
    public Decimal SubTotal { get; init; }
    public Decimal TaxTotal { get; init; }
    public Decimal ShippingTotal { get; init; }
    public Decimal DiscountTotal { get; init; }
    public Decimal DiscountPercent { get; init; }
    public Decimal WeightTotal { get; init; }
    public Decimal BusinessVolumeTotal { get; init; }
    public Decimal CommissionableVolumeTotal { get; init; }
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
    public Decimal ShippingTax { get; init; }
    public Decimal OrderTax { get; init; }
    public Decimal FedTaxTotal { get; init; }
    public Decimal StateTaxTotal { get; init; }
    public Decimal HandlingFeeTotal { get; init; }
    public OrderDetailResponse[] Details { get; init; }
    public ShipMethodResponse[] ShipMethods { get; init; }
    public string[] Warnings { get; init; }
    public string Trace { get; init; }

    public CalculateOrderResponse() : base()
    {
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
        Details = new OrderDetailResponse[0];
        ShipMethods = new ShipMethodResponse[0];
        Warnings = new string[0];
        Trace = String.Empty;
    }
}
