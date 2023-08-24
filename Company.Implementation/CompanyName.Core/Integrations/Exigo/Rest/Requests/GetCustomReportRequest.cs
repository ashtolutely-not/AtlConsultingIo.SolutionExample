// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomReportRequest : ApiRequest
{
    public int ReportID { get; init; }
    public ParameterRequest[] Parameters { get; init; }

    public GetCustomReportRequest( ) : base ( ) => Parameters = new ParameterRequest[ 0 ];
}
