namespace AtlConsultingIo.IntegrationOperations;

public record OperationContext( IntegrationKey IntegrationName, OperationContextID ContextID, IntegrationOption IntegrationOption, string OperationType );
