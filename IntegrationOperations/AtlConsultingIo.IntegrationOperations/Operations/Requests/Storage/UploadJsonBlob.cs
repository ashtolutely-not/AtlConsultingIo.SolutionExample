namespace AtlConsultingIo.IntegrationOperations;
public record UploadJsonBlob : IntegrationRequest<UploadJsonBlob>
{
    public UploadJsonBlob()
    {
    }

    public UploadJsonBlob( IntegrationRequest<UploadJsonBlob> original ) : base( original )
    {
    }

    public StorageBlobName BlobName { get; init; }
    public StorageBlobContainerName ContainerName { get; init; }
    public bool OverwriteIfExisting { get; init; }
    public object BlobContent { get; init; } = null!;
    public Dictionary<string , string> BlobTags { get; init; } = new Dictionary<string , string>();


}
