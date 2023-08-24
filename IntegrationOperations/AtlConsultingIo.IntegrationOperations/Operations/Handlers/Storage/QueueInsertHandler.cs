using Azure.Storage.Queues;

using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
internal class QueueInsertHandler : IIntegrationCommand<InsertQueueItem>
{
    private readonly IStorageClientFactory _factory;
    private readonly IValidator<InsertQueueItem> _validator;
    public QueueInsertHandler( IStorageClientFactory clientFactory , IValidator<InsertQueueItem> validator )
    {
        _factory = clientFactory;
        _validator = validator;
    }

    public async Task Execute(
        InsertQueueItem request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( QueueInsertHandler )
            );

        _validator.Validate( request );
        StorageClientConfiguration options = clientConfiguration.AsStorageOptions;
        StorageClientRequest clientReq = new(
                request.Key,
                StorageServiceType.StorageQueue,
                request.QueueName,
                options.ServiceConnectionString
            );

        StorageResourceClient resourceClient = await _factory.CreateResourceClientAsync( clientReq, cancellationToken ).ConfigureAwait(false);
        if ( (QueueClient?) resourceClient is not QueueClient _queue )
            throw StorageResourceClient.InvalidCastException<QueueClient>();

        _ = await _queue.SendMessageAsync(
                new BinaryData( request.QueueItem ) ,
                request.VisibilityTimeout ,
                request.TimeToLive ,
                cancellationToken
            ).ConfigureAwait( false );

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( QueueInsertHandler )
            );
    }


}
