using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public interface IIntegrationTransaction<TRequest>
    where TRequest : IntegrationRequest<TRequest>
{
    Task<TransactionSuccess<TResult>> Execute<TResult>( TRequest request , IntegratedClientSettings clientConfiguration , ILogger integrationLogger , CancellationToken cancellationToken )
        where TResult : class,new();
}
