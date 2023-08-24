// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetReportRequest : ApiRequest
{
    public int ReportID { get; init; }
    public ReportParameterRequest[] Parameters { get; init; }

    public GetReportRequest( ) : base ( ) => Parameters = new ReportParameterRequest[ 0 ];
}
