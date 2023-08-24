// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record TypedApiRequest
{
    public string TypeName { get; init; }
    public ITransactionMember? Request { get; init; }

    public TypedApiRequest( ) : base ( ) => TypeName = String.Empty;
}
