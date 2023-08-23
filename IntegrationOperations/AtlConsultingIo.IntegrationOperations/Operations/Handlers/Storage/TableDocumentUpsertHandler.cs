using Azure.Data.Tables;
using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
internal class TableDocumentUpsertHandler : IIntegrationCommand<UpsertTableDocument>
{
    private readonly IStorageClientFactory _factory;
    private readonly IValidator<UpsertTableDocument> _validator;
    public TableDocumentUpsertHandler( IStorageClientFactory clientFactory , IValidator<UpsertTableDocument> validator )
    {
        _factory = clientFactory;
        _validator = validator;
    }

    public async Task Execute(
        UpsertTableDocument request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace( 
                request.Key, 
                request.ContextID, 
                typeof(TableDocumentUpsertHandler)
            );     

        _validator.ValidateAndThrow( request );
        StorageClientConfiguration options = clientConfiguration.AsStorageOptions;
        StorageClientRequest clientReq = new( 
                request.Key, 
                StorageServiceType.StorageTable, 
                request.TableName, 
                options.ServiceConnectionString 
            );

        StorageResourceClient resourceClient = await _factory.CreateResourceClientAsync( clientReq, cancellationToken ).ConfigureAwait(false);
        if( (TableClient?)resourceClient is not TableClient _table )
            throw StorageResourceClient.InvalidCastException<TableClient>();


        _ = await _table.UpsertEntityAsync( request.EntityData , request.UpdateMode , cancellationToken ).ConfigureAwait(false);
        logger.OperationEndTrace( 
                request.Key, 
                request.ContextID, 
                typeof(TableDocumentUpsertHandler)
            );
    }

}
