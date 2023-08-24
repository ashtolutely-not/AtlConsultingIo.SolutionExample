// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record LoginCustomerRequest : ApiRequest
{
    public string LoginName { get; init; }
    public string Password { get; init; }
    public int CustomerID { get; init; }
    public string CustomerKey { get; init; }

    public LoginCustomerRequest() : base()
    {
        LoginName = String.Empty;
        Password = String.Empty;
        CustomerKey = String.Empty;
    }
}
