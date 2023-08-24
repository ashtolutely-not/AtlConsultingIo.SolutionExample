// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChangeOrderStatusRequest : ApiRequest
{
    public int OrderID { get; init; }
    public OrderStatusType OrderStatus { get; init; }
    public string OrderKey { get; init; }

    public ChangeOrderStatusRequest( ) : base ( ) => OrderKey = String.Empty;
}
