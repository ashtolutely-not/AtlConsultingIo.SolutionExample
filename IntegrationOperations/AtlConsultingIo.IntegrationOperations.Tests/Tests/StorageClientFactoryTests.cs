

using AtlConsultingIo.IntegrationOperations;
using AtlConsultingIo.IntegrationOperations.TestConsole;

using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Queues;

namespace AtlConsultingIo.Operations.Tests;
public class StorageClientFactoryTests
{
    private readonly StorageClientFactory _storageClientFactory;
    public StorageClientFactoryTests()
    {
        _storageClientFactory = new StorageClientFactory();
    }

    [Fact]
    public async Task Can_Create_Queue_Client()
    {
        var req = new StorageClientRequest(
                new IntegrationName("Test"),
                StorageServiceType.StorageQueue,
                new StorageQueueName("testqueue"),
                DevConnections.StorageAccount
            );

        StorageResourceClient resourceClient = await _storageClientFactory.CreateResourceClientAsync( req, CancellationToken.None );
        QueueClient? queueClient = ( QueueClient? ) resourceClient;

        queueClient.ShouldNotBeNull();
    }

    [Fact]
    public async Task Can_Create_Container_Client()
    {
        var req = new StorageClientRequest(
                new IntegrationName("Test"),
                StorageServiceType.StorageBlob,
                new StorageBlobContainerName("testcontainer"),
                DevConnections.StorageAccount
            );

        StorageResourceClient resourceClient = await _storageClientFactory.CreateResourceClientAsync( req, CancellationToken.None );
        BlobContainerClient? containerClient = (BlobContainerClient?)resourceClient;

        containerClient.ShouldNotBeNull();
    }

    [Fact]
    public async Task Can_Create_Table_Client()
    {
        var req = new StorageClientRequest(
                new IntegrationName("Test"),
                StorageServiceType.StorageTable,
                new StorageTableName("testtable"),
                DevConnections.StorageAccount
            );

        StorageResourceClient resourceClient = await _storageClientFactory.CreateResourceClientAsync( req, CancellationToken.None );
        TableClient? containerClient = (TableClient?)resourceClient;

        containerClient.ShouldNotBeNull();
    }

    [Fact]
    public async Task Can_Retrieve_Created_Client()
    {
        var req = new StorageClientRequest(
                new IntegrationName("Test"),
                StorageServiceType.StorageTable,
                new StorageTableName("testtable"),
                DevConnections.StorageAccount
            );

        StorageResourceClient result = await _storageClientFactory.CreateResourceClientAsync( req, CancellationToken.None );
        TableClient? tableClient = (TableClient?)result;
        tableClient.ShouldNotBeNull();

        StorageResourceClient result2 = await _storageClientFactory.CreateResourceClientAsync( req, CancellationToken.None );
        TableClient? tableClient2 = (TableClient?)result2;
        tableClient2.ShouldNotBeNull();

        //should be the same instance
        tableClient2.Equals( tableClient ).ShouldBeTrue();
    }
}
