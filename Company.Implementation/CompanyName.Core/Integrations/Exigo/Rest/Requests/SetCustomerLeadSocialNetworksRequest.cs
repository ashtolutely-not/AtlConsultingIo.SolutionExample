// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetCustomerLeadSocialNetworksRequest : ApiRequest, ITransactionMember
{
    public int CustomerLeadID { get; init; }
    public int CustomerID { get; init; }
    public CustomerLeadSocialNetworkRequest[] CustomerLeadSocialNetworks { get; init; }
    public string CustomerKey { get; init; }

    public SetCustomerLeadSocialNetworksRequest() : base()
    {
        CustomerLeadSocialNetworks = new CustomerLeadSocialNetworkRequest[0];
        CustomerKey = String.Empty;
    }
}
