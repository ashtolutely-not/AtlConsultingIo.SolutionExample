using Azure.Data.Tables;

namespace AtlConsultingIo.IntegrationOperations;
public record UpsertTableDocument : IntegrationRequest<UpsertTableDocument>
{
    public UpsertTableDocument()
    {
    }

    public UpsertTableDocument( IntegrationRequest<UpsertTableDocument> original ) : base( original )
    {
    }

    public StorageTableName TableName { get; init; }
    public TableUpdateMode UpdateMode { get; init; }
    public TableEntity EntityData { get; init; } = null!;


}

