// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record TransactionUp
{
    public string Type { get; init; }
    public ApiRequest? Request { get; init; }

    public TransactionUp( ) : base ( ) => Type = String.Empty;
}
