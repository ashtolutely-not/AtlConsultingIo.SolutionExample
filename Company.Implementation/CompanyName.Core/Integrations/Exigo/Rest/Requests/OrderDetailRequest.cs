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
public record OrderDetailRequest
{
    public string ItemCode { get; init; }
    public Guid? OrderDetailID { get; init; }
    public Guid? ParentOrderDetailID { get; init; }
    public Decimal Quantity { get; init; }
    public string ParentItemCode { get; init; }
    public Decimal? PriceEachOverride { get; init; }
    public Decimal? TaxableEachOverride { get; init; }
    public Decimal? ShippingPriceEachOverride { get; init; }
    public Decimal? BusinessVolumeEachOverride { get; init; }
    public Decimal? CommissionableVolumeEachOverride { get; init; }
    public Decimal? Other1EachOverride { get; init; }
    public Decimal? Other2EachOverride { get; init; }
    public Decimal? Other3EachOverride { get; init; }
    public Decimal? Other4EachOverride { get; init; }
    public Decimal? Other5EachOverride { get; init; }
    public Decimal? Other6EachOverride { get; init; }
    public Decimal? Other7EachOverride { get; init; }
    public Decimal? Other8EachOverride { get; init; }
    public Decimal? Other9EachOverride { get; init; }
    public Decimal? Other10EachOverride { get; init; }
    public string DescriptionOverride { get; init; }
    public string Reference1 { get; init; }
    public AdvancedAutoOptionsRequest? AdvancedAutoOptions { get; init; }

    public OrderDetailRequest() : base()
    {
        ItemCode = String.Empty;
        ParentItemCode = String.Empty;
        DescriptionOverride = String.Empty;
        Reference1 = String.Empty;
    }
}
