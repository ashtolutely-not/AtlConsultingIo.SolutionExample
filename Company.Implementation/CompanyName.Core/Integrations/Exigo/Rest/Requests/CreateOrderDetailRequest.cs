// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateOrderDetailRequest : ApiRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public int OrderLine { get; init; }
    public string ItemCode { get; init; }
    public string Description { get; init; }
    public Decimal Qty { get; init; }
    public Decimal? PriceEach { get; init; }
    public Decimal? PriceExt { get; init; }
    public Decimal? BVEach { get; init; }
    public Decimal? BusinessVolume { get; init; }
    public Decimal? CVEach { get; init; }
    public Decimal? CommissionableVolume { get; init; }
    public Decimal? ShippingPriceEach { get; init; }
    public Decimal? ChargeShippingOn { get; init; }
    public bool? IsTaxedInRegion { get; init; }
    public bool? IsTaxedInRegionFed { get; init; }
    public bool? IsTaxedInRegionState { get; init; }
    public Decimal? TaxablePriceEach { get; init; }
    public Decimal? Taxable { get; init; }
    public Decimal? CombinedTax { get; init; }
    public Decimal? FedTax { get; init; }
    public Decimal? StateTax { get; init; }
    public Decimal? CityTax { get; init; }
    public Decimal? CityLocalTax { get; init; }
    public Decimal? CountyTax { get; init; }
    public Decimal? CountyLocalTax { get; init; }
    public Decimal? ManualTax { get; init; }
    public bool? IsBackOrder { get; init; }
    public Decimal? WeightEach { get; init; }
    public Decimal? Other1Each { get; init; }
    public Decimal? Other1 { get; init; }
    public Decimal? Other2Each { get; init; }
    public Decimal? Other2 { get; init; }
    public Decimal? Other3Each { get; init; }
    public Decimal? Other3 { get; init; }
    public Decimal? Other4Each { get; init; }
    public Decimal? Other4 { get; init; }
    public Decimal? Other5Each { get; init; }
    public Decimal? Other5 { get; init; }
    public Decimal? Other6Each { get; init; }
    public Decimal? Other6 { get; init; }
    public Decimal? Other7Each { get; init; }
    public Decimal? Other7 { get; init; }
    public Decimal? Other8Each { get; init; }
    public Decimal? Other8 { get; init; }
    public Decimal? Other9Each { get; init; }
    public Decimal? Other9 { get; init; }
    public Decimal? Other10Each { get; init; }
    public Decimal? Other10 { get; init; }
    public Decimal? DiscountExt { get; init; }
    public Decimal? OriginalTaxableEach { get; init; }
    public Decimal? OriginalBVEach { get; init; }
    public Decimal? OriginalCVEach { get; init; }
    public Decimal? StateTaxable { get; init; }
    public bool? IsStateTaxOverride { get; init; }
    public int? DynamicKitItemID { get; init; }
    public Decimal? HandlingFee { get; init; }
    public string Reference1 { get; init; }
    public string OrderKey { get; init; }

    public CreateOrderDetailRequest() : base()
    {
        ItemCode = String.Empty;
        Description = String.Empty;
        Reference1 = String.Empty;
        OrderKey = String.Empty;
    }
}
