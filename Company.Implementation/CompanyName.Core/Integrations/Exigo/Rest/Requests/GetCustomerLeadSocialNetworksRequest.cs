// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerLeadSocialNetworksRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int CustomerLeadID { get; init; }
    public string CustomerKey { get; init; }

    public GetCustomerLeadSocialNetworksRequest( ) : base ( ) => CustomerKey = String.Empty;
}
