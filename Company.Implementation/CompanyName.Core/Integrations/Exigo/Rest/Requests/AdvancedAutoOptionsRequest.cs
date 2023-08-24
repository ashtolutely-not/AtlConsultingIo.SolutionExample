// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AdvancedAutoOptionsRequest
{
    public DateTime? ProcessWhileDate { get; init; }
    public DateTime? SkipUntilDate { get; init; }
    public DateTime? DetailStartDate { get; init; }
    public DateTime? DetailEndDate { get; init; }
    public int? DetailInterval { get; init; }

    public AdvancedAutoOptionsRequest() : base()
    {
    }
}
