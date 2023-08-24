// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ParameterRequest
{
    public string ParameterName { get; init; }
    public object? Value { get; init; }

    public ParameterRequest( ) : base ( ) => ParameterName = String.Empty;
}
