namespace AtlConsultingIo.IntegrationOperations;


public record FindJsonBlob : IntegrationRequest<FindJsonBlob>
{
    public FindJsonBlob()
    {
    }

    public FindJsonBlob( IntegrationRequest<FindJsonBlob> original ) : base( original )
    {
    }

    public StorageBlobContainerName ContainerName { get; init; }
    public StorageBlobName BlobName { get; init; }
    public Func<BinaryData,ValueTask<object>>? Convert { get; init; }


}
