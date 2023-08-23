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
