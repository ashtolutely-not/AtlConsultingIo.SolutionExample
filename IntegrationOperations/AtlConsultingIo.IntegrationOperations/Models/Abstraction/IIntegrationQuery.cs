using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public interface IIntegrationQuery<TRequest> 
    where TRequest : IntegrationRequest<TRequest>
{
    Task<QuerySuccess<TResult>> Execute<TResult>( TRequest request , IntegratedClientSettings clientConfiguration , ILogger integrationLogger , CancellationToken cancellationToken )
        where TResult : class, new();
}
