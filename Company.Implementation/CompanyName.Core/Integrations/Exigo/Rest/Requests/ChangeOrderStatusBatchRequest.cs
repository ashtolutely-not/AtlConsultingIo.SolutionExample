// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChangeOrderStatusBatchRequest : ApiRequest
{
    public OrderStatusType OrderStatus { get; init; }
    public OrderBatchDetailRequest[] Details { get; init; }

    public ChangeOrderStatusBatchRequest( ) : base ( ) => Details = new OrderBatchDetailRequest[ 0 ];
}
