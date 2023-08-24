// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetQualificationOverrideRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int OverrideID { get; init; }
    public bool Qualifies { get; init; }
    public int? PeriodType { get; init; }
    public int? StartPeriodID { get; init; }
    public int? EndPeriodID { get; init; }
    public Decimal? Amount { get; init; }
    public string CustomerKey { get; init; }

    public SetQualificationOverrideRequest( ) : base ( ) => CustomerKey = String.Empty;
}
