using Azure.Data.Tables;

namespace AtlConsultingIo.IntegrationOperations;

public record SearchTableDocuments : IntegrationRequest<SearchTableDocuments>

{
    public SearchTableDocuments()
    {
    }

    public SearchTableDocuments( IntegrationRequest<SearchTableDocuments> original ) : base( original )
    {
    }

    public StorageTableName TableName { get; init; }
    public List<string>? SelectFields { get; init; }
    public Dictionary<string , object> FilterConditions { get; init; } = null!;
    public Func<TableEntity, object>? Convert { get; init; }


}

