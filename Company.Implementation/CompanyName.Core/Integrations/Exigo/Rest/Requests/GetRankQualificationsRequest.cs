// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetRankQualificationsRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int RankID { get; init; }
    public int PeriodType { get; init; }
    public int? PeriodID { get; init; }
    public string CultureCode { get; init; }
    public int? RankGroupID { get; init; }
    public string CustomerKey { get; init; }

    public GetRankQualificationsRequest() : base()
    {
        CultureCode = String.Empty;
        CustomerKey = String.Empty;
    }
}
