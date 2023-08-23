namespace AtlConsultingIo.IntegrationOperations;

public record InsertQueueItem : IntegrationRequest<InsertQueueItem>
{
    public InsertQueueItem()
    {
    }

    public InsertQueueItem( IntegrationRequest<InsertQueueItem> original ) : base( original )
    {
    }

    public StorageQueueName QueueName { get; init; }
    public object QueueItem { get; init; } = null!;
    public TimeSpan? VisibilityTimeout { get; init; }
    public TimeSpan? TimeToLive { get; init; }



}

