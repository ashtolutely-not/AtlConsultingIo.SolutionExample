// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetAutoOrdersResponse : ApiResponse
{
    public AutoOrderResponse[] AutoOrders { get; init; }

    public GetAutoOrdersResponse( ) : base ( ) => AutoOrders = new AutoOrderResponse[ 0 ];
}
