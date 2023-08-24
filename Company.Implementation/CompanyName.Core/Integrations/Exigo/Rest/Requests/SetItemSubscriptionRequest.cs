// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetItemSubscriptionRequest : ApiRequest, ITransactionMember
{
    public string ItemCode { get; init; }
    public int? ItemID { get; init; }
    public Subscription[] Subscriptions { get; init; }

    public SetItemSubscriptionRequest() : base()
    {
        ItemCode = String.Empty;
        Subscriptions = new Subscription[0];
    }
}
