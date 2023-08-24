

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
public sealed record IntegrationServiceConfiguration
{
    internal static EventId EventID = new ( 666, "AtlConsultingIo.Operations" );

    private static readonly Options _defaultOptions = new();
    public Options? Value { get; set; }
    public IntegrationServiceConfiguration()
    {
        Value = _defaultOptions;
    }

    public record Options
    {
        public IntegrationOption[] IntegrationOptions { get; set; } = Array.Empty<IntegrationOption>();
        public IntegrationServiceLogSetting ServiceLoggingOptions { get; set; } = IntegrationServiceLogSetting.Default;
    }

}
