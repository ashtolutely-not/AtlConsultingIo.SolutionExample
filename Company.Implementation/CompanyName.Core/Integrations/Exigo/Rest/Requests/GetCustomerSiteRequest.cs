// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerSiteRequest : ApiRequest
{
    public string WebAlias { get; init; }
    public int? CustomerID { get; init; }
    public string CustomerKey { get; init; }

    public GetCustomerSiteRequest() : base()
    {
        WebAlias = String.Empty;
        CustomerKey = String.Empty;
    }
}
