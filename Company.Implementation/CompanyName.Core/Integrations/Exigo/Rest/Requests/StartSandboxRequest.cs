// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record StartSandboxRequest : ApiRequest
{
    public int SandboxID { get; init; }
    public bool EnableRevolvingCommissionRun { get; init; }
    public bool EnableBiSync { get; init; }
    public bool UseRealTimeBackup { get; init; }
    public int SyncFilterDays { get; init; }
    public string SyncSettingsEnable { get; init; }

    public StartSandboxRequest( ) : base ( ) => SyncSettingsEnable = String.Empty;
}
