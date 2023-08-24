// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetVolumesRequest : ApiRequest
{
    public int PeriodType { get; init; }
    public int? PeriodID { get; init; }
    public int? CustomerID { get; init; }
    public string CustomerKey { get; init; }

    public GetVolumesRequest( ) : base ( ) => CustomerKey = String.Empty;
}
