// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerLeadSocialNetworksResponse : ApiResponse
{
    public CustomerLeadSocialNetworksResponse[] CustomerLeadSocialNetwork { get; init; }

    public GetCustomerLeadSocialNetworksResponse( ) : base ( ) => CustomerLeadSocialNetwork = new CustomerLeadSocialNetworksResponse[ 0 ];
}
