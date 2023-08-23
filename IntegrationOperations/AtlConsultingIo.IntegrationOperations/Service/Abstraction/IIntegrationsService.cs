namespace AtlConsultingIo.IntegrationOperations;

public interface IIntegrationsService
{
    Task<CommandOperationResult> ExecuteIntegrationCommand<TRequest>( IntegrationRequest<TRequest> request , CancellationToken cancellationToken ) where TRequest : IntegrationRequest<TRequest>;
    Task<QueryOperationResult<TResult>> ExecuteIntegrationQuery<TRequest, TResult>( IntegrationRequest<TRequest> request , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
        where TResult : class, new();
    Task<TransactionOperationResult<TResult>> ExecuteIntegtrationTransaction<TRequest, TResult>( IntegrationRequest<TRequest> request , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
        where TResult : class, new();
}
