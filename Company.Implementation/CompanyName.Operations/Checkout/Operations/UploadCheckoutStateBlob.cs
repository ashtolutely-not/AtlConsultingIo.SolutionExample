using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Integrations;

using Newtonsoft.Json.Linq;


namespace CompanyName.Operations.Checkout;

public record UploadCheckoutStateBlob : UploadJsonBlob
{
    public UploadCheckoutStateBlob(
        OperationContextID contextID,
        JObject stateJson , 
        StorageBlobContainerName containerName,
        StorageBlobName blobName
        )
    {
        Key = AppStorageKey.Instance;
        ContextID = contextID;
        ContainerName = containerName ;
        BlobName = blobName;
        BlobContent = stateJson;
        
    }
}
