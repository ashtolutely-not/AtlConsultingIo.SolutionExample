// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChangeAutoOrderStatusRequest : ApiRequest
{
    public int AutoOrderID { get; init; }
    public AutoOrderStatusType AutoOrderStatus { get; init; }

    public ChangeAutoOrderStatusRequest() : base()
    {
    }
}
