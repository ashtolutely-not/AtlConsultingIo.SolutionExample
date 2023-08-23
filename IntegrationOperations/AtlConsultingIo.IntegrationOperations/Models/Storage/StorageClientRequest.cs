namespace AtlConsultingIo.IntegrationOperations;


public record StorageClientRequest( IntegrationKey IntegrationName, StorageServiceType ResourceType, IResourceID ResourceId, StorageAccountConnection AccountConnection );
