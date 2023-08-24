// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record Entity
{
    public string SchemaName { get; init; }
    public string DbSchema { get; init; }
    public string EntityName { get; init; }
    public string EntitySetName { get; init; }
    public Property[] Properties { get; init; }
    public List<Navigation> Navigations { get; init; }
    public KeyValuePairOfStringString[] NavigationList { get; init; }
    public int SyncTypeID { get; init; }
    public bool IsLog { get; init; }
    public int MaxLogDays { get; init; }
    public string LogDateField { get; init; }
    public bool ArchiveEnabled { get; init; }
    public string ArchiveDateField { get; init; }
    public int DaysBeforeArchive { get; init; }

    public Entity() : base()
    {
        SchemaName = String.Empty;
        DbSchema = String.Empty;
        EntityName = String.Empty;
        EntitySetName = String.Empty;
        Properties = new Property[0];
        Navigations = new();
        NavigationList = new KeyValuePairOfStringString[0];
        LogDateField = String.Empty;
        ArchiveDateField = String.Empty;
    }
}
