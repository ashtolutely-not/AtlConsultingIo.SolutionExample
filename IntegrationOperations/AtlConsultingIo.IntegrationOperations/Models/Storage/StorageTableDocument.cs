using Azure;
using Azure.Data.Tables;

namespace AtlConsultingIo.IntegrationOperations;
public record StorageTableDocument<T> : ITableEntity where T : class
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }
    public T? EntityData { get; init; }
    
    [JsonConstructor]
    private StorageTableDocument()
    {
        PartitionKey = RowKey = String.Empty;
        EntityData = default;
        Timestamp = default;
        ETag = default;
    }
    public StorageTableDocument( string rowKey , T entity )
    {
        PartitionKey = entity.GetType().Name;
        RowKey = rowKey;
        EntityData = entity;
    }
}
