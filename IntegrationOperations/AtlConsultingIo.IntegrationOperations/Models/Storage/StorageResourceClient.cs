using Azure.Storage.Blobs;
using Azure.Data.Tables;
using Azure.Storage.Queues;
using OneOf;

namespace AtlConsultingIo.IntegrationOperations;

public class StorageResourceClient : OneOfBase<BlobContainerClient , TableClient , QueueClient>
{

    protected StorageResourceClient( OneOf<BlobContainerClient , TableClient , QueueClient> _ ) : base( _ )
    {
    }

    public static implicit operator StorageResourceClient( BlobContainerClient _ ) => new( _ );
    public static implicit operator StorageResourceClient( TableClient _ ) => new( _ );
    public static implicit operator StorageResourceClient( QueueClient _ ) => new( _ );

    public static explicit operator BlobContainerClient?( StorageResourceClient _ ) => _.IsT0 ? _.AsT0 : null;
    public static explicit operator TableClient?( StorageResourceClient _ ) => _.IsT1 ? _.AsT1 : null;
    public static explicit operator QueueClient?( StorageResourceClient _ ) => _.IsT2 ? _.AsT2 : null;





    public static InvalidCastException InvalidCastException<TResourceClient>()
        => new InvalidCastException( $"The underlying type of StorageResourceClient instance does not match the expected type of {typeof( TResourceClient ).Name} " );
}


