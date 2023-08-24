// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetShoppingCartResponse : ApiResponse
{
    public int ExistingOrderID { get; init; }
    public int ExistingAutoOrderID { get; init; }
    public OrderDetailResponse[] Details { get; init; }

    public GetShoppingCartResponse( ) : base ( ) => Details = new OrderDetailResponse[ 0 ];
}
