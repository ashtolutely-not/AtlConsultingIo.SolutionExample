using Azure.Data.Tables;

namespace AtlConsultingIo.IntegrationOperations;
public record FindTableDocument : IntegrationRequest<FindTableDocument>

{
    public FindTableDocument()
    {
    }

    public FindTableDocument( IntegrationRequest<FindTableDocument> original ) : base( original )
    {
    }

    public string PartitionKey { get; init; } = String.Empty;
    public string RowKey { get; init; } = String.Empty;
    public StorageTableName TableName { get; init; }
    public List<string>? SelectFields { get; init; }
    public Func<TableEntity , object>? Convert { get; init; }


}

