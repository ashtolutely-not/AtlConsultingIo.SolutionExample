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
public record OrderImportDetail
{
    public string ParentItemCode { get; init; }
    public string ItemCode { get; init; }
    public string Description { get; init; }
    public Decimal Qty { get; init; }
    public Decimal WeightEach { get; init; }
    public Decimal CountyLocalTax { get; init; }
    public Decimal CountyTax { get; init; }
    public Decimal CityTax { get; init; }
    public Decimal StateTax { get; init; }
    public Decimal FedTax { get; init; }
    public Decimal TaxablePriceEach { get; init; }
    public Decimal CVEach { get; init; }
    public Decimal BVEach { get; init; }
    public Decimal PriceEach { get; init; }
    public Decimal Other10Each { get; init; }
    public Decimal Other9Each { get; init; }
    public Decimal Other8Each { get; init; }
    public Decimal Other7Each { get; init; }
    public Decimal Other6Each { get; init; }
    public Decimal Other5Each { get; init; }
    public Decimal Other4Each { get; init; }
    public Decimal Other3Each { get; init; }
    public Decimal Other2Each { get; init; }
    public Decimal Other1Each { get; init; }
    public string Reference1 { get; init; }

    public OrderImportDetail() : base()
    {
        ParentItemCode = String.Empty;
        ItemCode = String.Empty;
        Description = String.Empty;
        Reference1 = String.Empty;
    }
}
