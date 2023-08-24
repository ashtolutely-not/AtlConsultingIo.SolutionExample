// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateOrderResponse : BaseCalculateOrderResponse
{
    public int OrderID { get; init; }
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
    public Decimal HandlingFeeTotal { get; init; }
    public OrderDetailResponse[] Details { get; init; }
    public string[] Warnings { get; init; }
    public string OrderKey { get; init; }

    public CreateOrderResponse() : base()
    {
        Details = new OrderDetailResponse[0];
        Warnings = new string[0];
        OrderKey = String.Empty;
    }
}
