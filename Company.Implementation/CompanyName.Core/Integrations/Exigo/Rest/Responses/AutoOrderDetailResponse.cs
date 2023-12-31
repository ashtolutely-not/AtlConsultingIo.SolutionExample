// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AutoOrderDetailResponse
{
    public string ItemCode { get; init; }
    public string Description { get; init; }
    public Decimal Quantity { get; init; }
    public Decimal PriceEach { get; init; }
    public Decimal PriceTotal { get; init; }
    public Decimal BusinessVolumeEach { get; init; }
    public Decimal BusinesVolume { get; init; }
    public Decimal CommissionableVolumeEach { get; init; }
    public Decimal CommissionableVolume { get; init; }
    public string ParentItemCode { get; init; }
    public Decimal? PriceEachOverride { get; init; }
    public Decimal? TaxableEachOverride { get; init; }
    public Decimal? ShippingPriceEachOverride { get; init; }
    public Decimal? BusinessVolumeEachOverride { get; init; }
    public Decimal? CommissionableVolumeEachOverride { get; init; }
    public string Reference1 { get; init; }
    public DateTime? ProcessWhileDate { get; init; }
    public DateTime? SkipUntilDate { get; init; }
    public DateTime? DetailStartDate { get; init; }
    public DateTime? DetailEndDate { get; init; }
    public int? DetailInterval { get; init; }

    public AutoOrderDetailResponse() : base()
    {
        ItemCode = String.Empty;
        Description = String.Empty;
        ParentItemCode = String.Empty;
        Reference1 = String.Empty;
    }
}
