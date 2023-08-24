using System.Collections.Concurrent;

using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;

namespace AtlConsultingIo.IntegrationOperations;

internal class StorageClientFactory : IStorageClientFactory
{

    private static readonly ConcurrentDictionary<StorageServiceKey,StorageServiceClient> _serviceClients = new();
    private static readonly ConcurrentDictionary<StorageResourceKey,StorageResourceClient> _resourceClients = new();

    public async Task<StorageResourceClient> CreateResourceClientAsync( StorageClientRequest clientRequest, CancellationToken cancellationToken ) 
    {
        StorageServiceKey serviceKey = new( clientRequest.IntegrationName, clientRequest.AccountConnection , clientRequest.ResourceType );
        StorageResourceKey resourceKey = new( serviceKey, clientRequest.ResourceId );
        return await GetResourceClient(resourceKey, cancellationToken ).ConfigureAwait( false );
    }

    public async ValueTask<StorageResourceClient> GetResourceClient( StorageResourceKey resourceKey , CancellationToken cancellationToken )
    {
        //check if we've already done this before
        if( _resourceClients.TryGetValue( resourceKey, out StorageResourceClient? client ) )
            return client;

        //Get or Create new service client
        StorageServiceClient serviceClient = GetServiceClient( resourceKey.ServiceKey );
        StorageResourceClient resourceClient = resourceKey.ServiceKey.ServiceType switch
        {
            StorageServiceType.StorageQueue => await CreateQueueClient( serviceClient, resourceKey, cancellationToken ),
            StorageServiceType.StorageBlob => await CreateContainerClient( serviceClient, resourceKey, cancellationToken ),
            StorageServiceType.StorageTable => await CreateTableClient( serviceClient, resourceKey, cancellationToken ),
            _ => throw new InvalidOperationException( $"StorageClientFactory does not support the creation of a { resourceKey.ServiceKey.ServiceType.ToString() } resource." )
        };

        return resourceClient;
    }
    public StorageServiceClient GetServiceClient( StorageServiceKey serviceKey  ) 
    {
        bool exists = _serviceClients.TryGetValue( serviceKey, out StorageServiceClient? instance );
        if ( exists && instance is not null ) return instance;

        //check if we've created the service client before, but the connection has changed due to options reload
        //if so, dispose of the old client and create a new one
        TryDispose( serviceKey );

        return serviceKey.ServiceType switch
        {
            StorageServiceType.StorageBlob => new BlobServiceClient( serviceKey.ConnectionString ),
            StorageServiceType.StorageTable => new TableServiceClient( serviceKey.ConnectionString ),
            StorageServiceType.StorageQueue => new QueueServiceClient( serviceKey.ConnectionString ),
            _ => throw new NotImplementedException($"Factory does not support create of a { serviceKey.ServiceType } service client.")
        };
    }
    async Task<QueueClient> CreateQueueClient( StorageServiceClient serviceClient, StorageResourceKey resourceKey, CancellationToken cancellationToken )
    {
        QueueServiceClient? queueService = (QueueServiceClient?)serviceClient;
        if( queueService is null )
            throw StorageServiceClient.InvalidCastException<QueueServiceClient>();

        QueueClient queueClient = queueService.GetQueueClient( resourceKey.ResourceName.Value );

        _ = await queueClient.CreateIfNotExistsAsync(null, cancellationToken);
        _ = _resourceClients.TryAdd( resourceKey, queueClient );

        return queueClient;
    }
    async Task<TableClient> CreateTableClient( StorageServiceClient serviceClient, StorageResourceKey resourceKey, CancellationToken cancellationToken )
    {
        TableServiceClient? tableService = (TableServiceClient?)serviceClient;
        if( tableService is null )
            throw StorageServiceClient.InvalidCastException<TableServiceClient>();

        TableClient resourceClient = tableService.GetTableClient( resourceKey.ResourceName.Value );

        _ = await resourceClient.CreateIfNotExistsAsync(cancellationToken);
        _ = _resourceClients.TryAdd( resourceKey, resourceClient );

        return resourceClient;
    }
    async Task<BlobContainerClient> CreateContainerClient( StorageServiceClient serviceClient, StorageResourceKey resourceKey, CancellationToken cancellationToken )
    {
        BlobServiceClient ? blobService =(BlobServiceClient ?) serviceClient;
        if( blobService is null )
            throw StorageServiceClient.InvalidCastException<BlobServiceClient>();

        BlobContainerClient containerClient = blobService.GetBlobContainerClient( resourceKey.ResourceName.Value );

        _ = await containerClient.CreateIfNotExistsAsync( cancellationToken: cancellationToken );
        _ = _resourceClients.TryAdd( resourceKey, containerClient );    

        return containerClient;
    }

    void TryDispose( StorageServiceKey key )
    {
        IEnumerable<KeyValuePair<StorageServiceKey,StorageServiceClient>> staleConnections = _serviceClients.Where( kv =>
            kv.Key.IntegrationName.Equals(key.IntegrationName)
            && kv.Key.ServiceType.Equals( key.ServiceType )
            && !kv.Key.ConnectionString.Equals(key.ConnectionString) );

        foreach( var conn in staleConnections )
        {
            bool removed = _serviceClients.TryRemove( conn.Key , out StorageServiceClient? client );
            if ( client is not null )
                if ( client is IDisposable disposable )
                    disposable.Dispose();
        }
    }
    void TryDispose( StorageResourceKey resourceKey )
    {
        IEnumerable<KeyValuePair<StorageResourceKey, StorageResourceClient>> staleConnections = 
            _resourceClients.Where( kvp => 
                kvp.Key.ServiceKey.IntegrationName.Equals( resourceKey.ServiceKey.IntegrationName )
                && kvp.Key.ServiceKey.ServiceType.Equals( resourceKey.ServiceKey.ServiceType)
                && kvp.Key.ResourceName.Equals( resourceKey.ResourceName)
                && !kvp.Key.ServiceKey.ConnectionString.Equals( resourceKey.ServiceKey.ConnectionString ));

        if( !staleConnections.HasItems() )
            return;

        foreach( var conn in staleConnections )
        {
            bool removed = _resourceClients.TryRemove( conn.Key, out StorageResourceClient? resourceClient );
            if( resourceClient is not null )
                if( resourceClient is IDisposable _disposable )
                    _disposable.Dispose();
        }
    }


}

#region Interface Definition

public interface IStorageClientFactory
{
    Task<StorageResourceClient> CreateResourceClientAsync( StorageClientRequest clientRequest, CancellationToken cancellationToken );
    ValueTask<StorageResourceClient> GetResourceClient( StorageResourceKey resourceKey , CancellationToken cancellationToken );
    StorageServiceClient GetServiceClient( StorageServiceKey serviceKey );
}

#endregion

#region Dictionary Keys
public readonly record struct StorageServiceKey( IntegrationKey IntegrationName ,string ConnectionString, StorageServiceType ServiceType ) : IEquatable<StorageServiceKey>
{
    public bool IsDefault =>  string.IsNullOrWhiteSpace( ConnectionString );

    public bool Equals( StorageServiceKey? other )
    {
        if ( !other.HasValue ) return false;

        StorageServiceKey  _other = other.Value;

        return  _other.IntegrationName.Equals( IntegrationName )
                && ServiceType.Equals( _other.ServiceType )
                && ConnectionString.Equals( _other.ConnectionString );
    }
}

public readonly record struct StorageResourceKey( StorageServiceKey ServiceKey, IResourceID ResourceName );

#endregion
