// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;

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
