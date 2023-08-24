// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record Sandbox
{
    public int CompanyID { get; init; }
    public int SandboxID { get; init; }
    public string Description { get; init; }
    public SandboxType Type { get; init; }
    public string Status { get; init; }
    public DateTime? StartDate { get; init; }
    public Decimal? PercentComplete { get; init; }
    public Decimal Hours { get; init; }
    public bool AllowVolumePush { get; init; }
    public bool AllowBiSync { get; init; }
    public int? SyncFilterDays { get; init; }
    public bool UseRealTimeBackup { get; init; }

    public Sandbox() : base()
    {
        Description = String.Empty;
        Status = String.Empty;
    }
}
