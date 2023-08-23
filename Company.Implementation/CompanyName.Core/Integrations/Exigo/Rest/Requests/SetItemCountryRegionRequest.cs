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
public record SetItemCountryRegionRequest : ApiRequest, ITransactionMember
{
    public string ItemCode { get; init; }
    public string CountryCode { get; init; }
    public string RegionCode { get; init; }
    public bool? Taxed { get; init; }
    public bool? TaxedFed { get; init; }
    public bool? TaxedState { get; init; }
    public bool? UseTaxOverride { get; init; }
    public Decimal? TaxOverridePct { get; init; }
    public bool BulkUpdate { get; init; }

    public SetItemCountryRegionRequest() : base()
    {
        ItemCode = String.Empty;
        CountryCode = String.Empty;
        RegionCode = String.Empty;
    }
}
