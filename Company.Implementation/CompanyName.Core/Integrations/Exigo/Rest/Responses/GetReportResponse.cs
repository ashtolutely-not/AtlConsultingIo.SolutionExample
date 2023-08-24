// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
using System.Data;
namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetReportResponse : ApiResponse
{
    public DataSet? ReportData { get; init; }

    public GetReportResponse() : base()
    {
    }
}
