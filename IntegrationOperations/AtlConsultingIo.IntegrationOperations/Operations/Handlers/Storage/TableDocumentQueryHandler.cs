using Azure;
using Azure.Data.Tables;
using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
public class TableDocumentQueryHandler: IIntegrationQuery<FindTableDocument>
{
    private readonly IStorageClientFactory _factory;
    private readonly IValidator<FindTableDocument> _validator;
    public TableDocumentQueryHandler( IStorageClientFactory clientFactory , IValidator<FindTableDocument> validator  )
    {
        _factory = clientFactory;
        _validator = validator;
    }

    public async Task<QuerySuccess<TResult>> Execute<TResult>(
        FindTableDocument request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( TableDocumentQueryHandler )
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

        NullableResponse<TableEntity> response = await _table.GetEntityIfExistsAsync<TableEntity>(
                    request.PartitionKey,
                    request.RowKey,
                    request.SelectFields,
                    cancellationToken
                ).ConfigureAwait( false );

        QuerySuccess<TResult> result = response.HasValue ? GetResult<TResult>( request, response.Value ) : NotFoundResult.Instance;     

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( TableDocumentQueryHandler )
            );

        return result;
    }

    private TResult GetResult<TResult>( FindTableDocument request, TableEntity entity )
    {
        if( request.Convert is not null )
        {
            var anon = request.Convert( entity );
            return anon is not TResult _result
                    ? throw new InvalidCastException( $"Value returned by {nameof( FindTableDocument )}.{nameof( FindTableDocument.Convert )} cannot be cast to expected return type of {( typeof( TResult ).Name )}" )
                    : _result;
        }

        return (TResult)TableEntityMapper.MapResult( entity, typeof( TResult ) );
    }
}
