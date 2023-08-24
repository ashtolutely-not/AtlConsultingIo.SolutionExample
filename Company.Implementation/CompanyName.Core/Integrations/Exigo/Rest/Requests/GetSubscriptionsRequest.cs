// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetSubscriptionsRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }
    public bool IncludeInactive { get; init; }

    public GetSubscriptionsRequest( ) : base ( ) => CustomerKey = String.Empty;
}
