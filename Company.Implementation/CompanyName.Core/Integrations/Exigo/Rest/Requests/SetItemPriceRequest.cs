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
public record SetItemPriceRequest : ApiRequest, ITransactionMember
{
    public string ItemCode { get; init; }
    public string CurrencyCode { get; init; }
    public int PriceType { get; init; }
    public Decimal? Price { get; init; }
    public Decimal? BusinessVolume { get; init; }
    public Decimal? CommissionableVolume { get; init; }
    public Decimal? TaxablePrice { get; init; }
    public Decimal? ShippingPrice { get; init; }
    public Decimal? Other1Price { get; init; }
    public Decimal? Other2Price { get; init; }
    public Decimal? Other3Price { get; init; }
    public Decimal? Other4Price { get; init; }
    public Decimal? Other5Price { get; init; }
    public Decimal? Other6Price { get; init; }
    public Decimal? Other7Price { get; init; }
    public Decimal? Other8Price { get; init; }
    public Decimal? Other9Price { get; init; }
    public Decimal? Other10Price { get; init; }

    public SetItemPriceRequest() : base()
    {
        ItemCode = String.Empty;
        CurrencyCode = String.Empty;
    }
}
