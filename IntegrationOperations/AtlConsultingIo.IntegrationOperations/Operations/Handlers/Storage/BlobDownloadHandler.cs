using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using Azure;
using Microsoft.Extensions.Logging;
using FluentValidation;
using Azure.Data.Tables;

namespace AtlConsultingIo.IntegrationOperations;

public class BlobDownloadHandler : IIntegrationQuery<FindJsonBlob>

{
    private readonly IStorageClientFactory _clientFactory;
    private readonly IValidator<FindJsonBlob> _validator;
    public BlobDownloadHandler( IStorageClientFactory storageClientFactory , IValidator<FindJsonBlob> validator )
    {
        _clientFactory = storageClientFactory;
        _validator = validator;
    }

    public async Task<QuerySuccess<TResult>> Execute<TResult>(
        FindJsonBlob request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) 
        where TResult : class, new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( BlobDownloadHandler )
            );

        _validator.ValidateAndThrow( request );
        StorageClientConfiguration options = clientConfiguration.AsStorageOptions;
        StorageClientRequest clientReq = new(
                request.Key,
                StorageServiceType.StorageBlob,
                request.ContainerName,
                options.ServiceConnectionString
            );

        StorageResourceClient resourceClient = await _clientFactory.CreateResourceClientAsync( clientReq, cancellationToken ).ConfigureAwait(false);
        if( (BlobContainerClient?)resourceClient is not BlobContainerClient _container )
            throw StorageResourceClient.InvalidCastException<BlobContainerClient>();

        BlobClient blobClient = _container.GetBlobClient( request.BlobName.WithJsonFileExtension() );
        NullableResponse<BlobDownloadResult> response = await blobClient.DownloadContentAsync( cancellationToken );
        QuerySuccess<TResult> result = response.HasValue 
                        ? await GetResult<TResult>( response.Value.Content , request ) 
                        : NotFoundResult.Instance;

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( BlobDownloadHandler )
            );

        return result;
    }



    public async ValueTask<TResult> GetResult<TResult>( BinaryData data , FindJsonBlob request )
        where TResult : class, new()
    {
        if ( request.Convert is not null )
        {
            var anon = await request.Convert( data );
            return anon is not TResult _result
                    ? throw new InvalidCastException( $"Value returned by {nameof( FindJsonBlob )}.{nameof( FindJsonBlob.Convert )} cannot be cast to expected return type of {( typeof( TResult ).Name )}" )
                    : _result;
        }

        TResult? result = JsonConvert.DeserializeObject<TResult>( data.ToString() );
        return result is null
                ? throw new JsonSerializationException( $"Could not deserialize http response content to type of {typeof( TResult ).Name}" )
                : result;
    }


}
