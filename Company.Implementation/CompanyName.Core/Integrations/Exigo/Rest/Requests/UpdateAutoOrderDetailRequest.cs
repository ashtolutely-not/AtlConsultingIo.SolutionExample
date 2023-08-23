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
public record UpdateAutoOrderDetailRequest : ApiRequest, ITransactionMember
{
    public int AutoOrderID { get; init; }
    public int OrderLine { get; init; }
    public int ItemID { get; init; }
    public Decimal Qty { get; init; }
    public Decimal? ManualPriceEach { get; init; }
    public Decimal? ManualTaxablePriceEach { get; init; }
    public Decimal? ManualShippingPriceEach { get; init; }
    public Decimal? ManualBVEach { get; init; }
    public Decimal? ManualCVEach { get; init; }
    public string Description { get; init; }
    public int? PeriodDescriptionTy { get; init; }
    public Decimal? PriceEach { get; init; }
    public Decimal? PriceExt { get; init; }
    public Decimal? BVEach { get; init; }
    public Decimal? BusinessVolume { get; init; }
    public Decimal? CVEach { get; init; }
    public Decimal? CommissionableVolume { get; init; }
    public int? DynamicKitItemID { get; init; }
    public string Reference1 { get; init; }

    public UpdateAutoOrderDetailRequest() : base()
    {
        Description = String.Empty;
        Reference1 = String.Empty;
    }
}
