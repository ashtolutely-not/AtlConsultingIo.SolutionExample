// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ReportParameterRequest
{
    public string ParameterName { get; init; }
    public string Value { get; init; }

    public ReportParameterRequest() : base()
    {
        ParameterName = String.Empty;
        Value = String.Empty;
    }
}
