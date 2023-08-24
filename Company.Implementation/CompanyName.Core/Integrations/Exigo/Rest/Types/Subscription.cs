// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record Subscription
{
    public int SubscriptionID { get; init; }
    public int TimeAdjustmentDays { get; init; }

    public Subscription() : base()
    {
    }
}
