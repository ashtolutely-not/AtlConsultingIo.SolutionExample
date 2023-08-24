// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCommissionReportRequest : ApiRequest
{
    public int PeriodType { get; init; }
    public int? PeriodID { get; init; }
    public string ReportName { get; init; }
    public string ParameterData { get; init; }

    public GetCommissionReportRequest() : base()
    {
        ReportName = String.Empty;
        ParameterData = String.Empty;
    }
}
