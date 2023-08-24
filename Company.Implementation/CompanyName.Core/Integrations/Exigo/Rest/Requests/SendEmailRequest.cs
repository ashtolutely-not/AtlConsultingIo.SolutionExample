// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SendEmailRequest : ApiRequest
{
    public int? CustomerID { get; init; }
    public string MailFrom { get; init; }
    public string MailTo { get; init; }
    public string Subject { get; init; }
    public string Body { get; init; }
    public string CustomerKey { get; init; }

    public SendEmailRequest() : base()
    {
        MailFrom = String.Empty;
        MailTo = String.Empty;
        Subject = String.Empty;
        Body = String.Empty;
        CustomerKey = String.Empty;
    }
}
