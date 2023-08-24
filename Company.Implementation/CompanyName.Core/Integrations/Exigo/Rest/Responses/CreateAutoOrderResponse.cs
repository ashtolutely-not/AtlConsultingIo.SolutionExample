// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateAutoOrderResponse : BaseCalculateOrderResponse
{
    public int AutoOrderID { get; init; }
    public string Description { get; init; }
    public Decimal Total { get; init; }
    public Decimal SubTotal { get; init; }
    public Decimal TaxTotal { get; init; }
    public Decimal ShippingTotal { get; init; }
    public Decimal DiscountTotal { get; init; }
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
    public Decimal ShippingTax { get; init; }
    public Decimal OrderTax { get; init; }
    public OrderDetailResponse[] Details { get; init; }

    public CreateAutoOrderResponse() : base()
    {
        Description = String.Empty;
        Details = new OrderDetailResponse[0];
    }
}
