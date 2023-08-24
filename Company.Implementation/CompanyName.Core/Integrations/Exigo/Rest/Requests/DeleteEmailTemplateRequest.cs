// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DeleteEmailTemplateRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public int TemplateID { get; init; }
    public string CustomerKey { get; init; }

    public DeleteEmailTemplateRequest( ) : base ( ) => CustomerKey = String.Empty;
}
