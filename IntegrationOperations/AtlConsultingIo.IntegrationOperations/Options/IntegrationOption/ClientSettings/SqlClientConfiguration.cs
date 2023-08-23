
namespace AtlConsultingIo.IntegrationOperations;

public sealed record SqlClientConfiguration
{
    public SqlServerConnection SqlConnectionString { get; init; }
    public int RowQueryTimeout { get; init; } 
    public int SearchQueryTimeout { get; init; } 
    public int CommandTimeout { get; init; } 

    public static readonly SqlClientConfiguration Default = new();
}
