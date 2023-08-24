// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record OrderBatchDetailRequest
{
    public int OrderID { get; init; }
    public string TrackingNumber1 { get; init; }
    public string TrackingNumber2 { get; init; }
    public string TrackingNumber3 { get; init; }
    public string TrackingNumber4 { get; init; }
    public string TrackingNumber5 { get; init; }
    public DateTime? ShippedDate { get; init; }
    public string OrderKey { get; init; }

    public OrderBatchDetailRequest() : base()
    {
        TrackingNumber1 = String.Empty;
        TrackingNumber2 = String.Empty;
        TrackingNumber3 = String.Empty;
        TrackingNumber4 = String.Empty;
        TrackingNumber5 = String.Empty;
        OrderKey = String.Empty;
    }
}
