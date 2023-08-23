namespace AtlConsultingIo.IntegrationOperations;

public record SearchJsonBlobs : IntegrationRequest<SearchJsonBlobs>

{
    public SearchJsonBlobs()
    {
    }

    public SearchJsonBlobs( IntegrationRequest<SearchJsonBlobs> original ) : base( original )
    {
    }

    public StorageBlobContainerName ContainerName { get; init; }
    public   Dictionary<string,string> Tags { get; init; } = null!;
    public Func<BinaryData,ValueTask<object>>? ResultConverter { get; init; }


}


