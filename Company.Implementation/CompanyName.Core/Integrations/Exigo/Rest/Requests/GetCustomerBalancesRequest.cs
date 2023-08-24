// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerBalancesRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }

    public GetCustomerBalancesRequest( ) : base ( ) => CustomerKey = String.Empty;
}
