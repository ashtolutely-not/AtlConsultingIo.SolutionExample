// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetOrdersResponse : ApiResponse
{
    public OrderResponse[] Orders { get; init; }
    public int RecordCount { get; init; }

    public GetOrdersResponse( ) : base ( ) => Orders = new OrderResponse[ 0 ];
}
