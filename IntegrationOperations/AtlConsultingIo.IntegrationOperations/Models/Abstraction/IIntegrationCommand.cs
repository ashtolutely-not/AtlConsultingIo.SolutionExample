using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public interface IIntegrationCommand<TRequest>  
    where TRequest : IntegrationRequest<TRequest>
{
    Task Execute( TRequest request , IntegratedClientSettings clientConfiguration , ILogger integrationLogger , CancellationToken cancellationToken );
}
