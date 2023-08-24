// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetCustomerSocialNetworksRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public CustomerSocialNetworkRequest[] CustomerSocialNetworks { get; init; }
    public string CustomerKey { get; init; }

    public SetCustomerSocialNetworksRequest() : base()
    {
        CustomerSocialNetworks = new CustomerSocialNetworkRequest[0];
        CustomerKey = String.Empty;
    }
}
