// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateEmailTemplateRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public string Description { get; init; }
    public string Content { get; init; }
    public string CustomerKey { get; init; }

    public CreateEmailTemplateRequest() : base()
    {
        Description = String.Empty;
        Content = String.Empty;
        CustomerKey = String.Empty;
    }
}
