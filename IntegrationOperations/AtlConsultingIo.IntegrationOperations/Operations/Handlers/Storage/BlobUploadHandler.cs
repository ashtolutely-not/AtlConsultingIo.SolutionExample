
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

internal class BlobUploadHandler : IIntegrationCommand<UploadJsonBlob>
{
    private readonly IStorageClientFactory _factory;
    private readonly IValidator<UploadJsonBlob> _validator;
    public BlobUploadHandler( IStorageClientFactory clientFactory , IValidator<UploadJsonBlob> validator )
    {
        _factory = clientFactory;
        _validator = validator;
    }

    public async Task Execute(
        UploadJsonBlob request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace( 
                request.Key, 
                request.ContextID, 
                typeof(BlobUploadHandler)
            );     

        _validator.Validate( request );
        StorageClientConfiguration options = clientConfiguration.AsStorageOptions;
        StorageClientRequest clientReq = new( 
                request.Key, 
                StorageServiceType.StorageBlob, 
                request.ContainerName, 
                options.ServiceConnectionString 
            );

        StorageResourceClient resourceClient = await _factory.CreateResourceClientAsync( clientReq, cancellationToken ).ConfigureAwait(false);
        if( (BlobContainerClient?)resourceClient is not BlobContainerClient _container )
            throw StorageResourceClient.InvalidCastException<BlobContainerClient>();

        BlobClient blobClient = _container.GetBlobClient( request.BlobName.WithJsonFileExtension() );
        _ = await blobClient.UploadAsync( 
                new BinaryData( request.BlobContent ) , 
                new BlobUploadOptions() 
                {
                    Tags = request.BlobTags,
                    Conditions = null
                } , 
                cancellationToken 
            ).ConfigureAwait(false);

        logger.OperationEndTrace( 
                request.Key, 
                request.ContextID, 
                typeof(BlobUploadHandler)
            );
    }


}
