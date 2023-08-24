// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerSocialNetworksResponse : ApiResponse
{
    public CustomerSocialNetworksResponse[] CustomerSocialNetwork { get; init; }

    public GetCustomerSocialNetworksResponse( ) : base ( ) => CustomerSocialNetwork = new CustomerSocialNetworksResponse[ 0 ];
}
