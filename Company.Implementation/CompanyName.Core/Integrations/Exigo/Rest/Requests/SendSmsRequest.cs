// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SendSmsRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string Message { get; init; }
    public string Phone { get; init; }
    public string CustomerKey { get; init; }

    public SendSmsRequest() : base()
    {
        Message = String.Empty;
        Phone = String.Empty;
        CustomerKey = String.Empty;
    }
}
