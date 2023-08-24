// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetQualificationOverridesRequest : ApiRequest
{
    public int? CustomerID { get; init; }
    public int? OverrideID { get; init; }
    public int? BatchSize { get; init; }
    public string CustomerKey { get; init; }

    public GetQualificationOverridesRequest( ) : base ( ) => CustomerKey = String.Empty;
}
