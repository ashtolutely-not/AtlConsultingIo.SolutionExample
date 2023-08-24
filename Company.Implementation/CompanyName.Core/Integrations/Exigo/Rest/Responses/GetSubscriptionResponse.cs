// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetSubscriptionResponse : ApiResponse
{
    public SubscriptionStatus Status { get; init; }
    public DateTime StartDate { get; init; }
    public DateTime ExpireDate { get; init; }

    public GetSubscriptionResponse() : base()
    {
    }
}
