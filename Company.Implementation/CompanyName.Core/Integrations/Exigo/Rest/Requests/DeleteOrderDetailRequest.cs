// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DeleteOrderDetailRequest : ApiRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public int OrderLine { get; init; }
    public string OrderKey { get; init; }

    public DeleteOrderDetailRequest( ) : base ( ) => OrderKey = String.Empty;
}
