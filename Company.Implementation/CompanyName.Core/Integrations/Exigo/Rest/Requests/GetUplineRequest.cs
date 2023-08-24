// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetUplineRequest : ApiRequest
{
    public TreeType TreeType { get; init; }
    public int CustomerID { get; init; }
    public int PeriodType { get; init; }
    public int? PeriodID { get; init; }
    public string CustomerKey { get; init; }
    public int? BatchSize { get; init; }
    public int? BatchOffset { get; init; }

    public GetUplineRequest( ) : base ( ) => CustomerKey = String.Empty;
}
