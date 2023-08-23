namespace AtlConsultingIo.IntegrationOperations;

public interface IIntegrationsLogger
{
    ValueTask CreateExecutionLog<TRequest>( IntegrationType integrationType , IntegrationRequest<TRequest> operationRequest , IIntegrationOperationResult operationResult ) where TRequest : class;
    void LogIntegrationException( OperationContext context , Exception exception );
    void LogServiceException( OperationContext context , Exception exception );
}
