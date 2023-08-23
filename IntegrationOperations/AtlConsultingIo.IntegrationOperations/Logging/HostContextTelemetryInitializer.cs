using Microsoft.Extensions.Options;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.ApplicationInsights.Channel;

namespace AtlConsultingIo.IntegrationOperations;
public class HostContextTelemetryInitializer : ITelemetryInitializer
{
    private readonly IOptionsMonitor<AzureHostContext> _contextOption;
    public HostContextTelemetryInitializer( IOptionsMonitor<AzureHostContext> hostContext )
    {
        _contextOption = hostContext;
    }

    public void Initialize( ITelemetry telemetry )
    {
        telemetry.Context.GlobalProperties[nameof(AzureHostContext.EnvironmentName)] = _contextOption.CurrentValue.EnvironmentName;
        telemetry.Context.GlobalProperties[nameof(AzureHostContext.ApplicationName)] = _contextOption.CurrentValue.ApplicationName;
        telemetry.Context.GlobalProperties[nameof(AzureHostContext.InstanceID)] = _contextOption.CurrentValue.InstanceID;

    }
}
