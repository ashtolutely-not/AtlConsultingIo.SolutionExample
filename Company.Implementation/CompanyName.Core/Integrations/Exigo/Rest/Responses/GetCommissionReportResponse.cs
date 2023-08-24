// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCommissionReportResponse : ApiResponse
{
    public string ReportData { get; init; }

    public GetCommissionReportResponse( ) : base ( ) => ReportData = String.Empty;
}
