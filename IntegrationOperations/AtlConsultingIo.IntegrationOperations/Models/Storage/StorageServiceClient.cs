using Azure.Storage.Blobs;
using Azure.Data.Tables;
using Azure.Storage.Queues;
using OneOf;

namespace AtlConsultingIo.IntegrationOperations;

public class StorageServiceClient : OneOfBase<BlobServiceClient , TableServiceClient , QueueServiceClient>
{
    protected StorageServiceClient( OneOf<BlobServiceClient , TableServiceClient , QueueServiceClient> input ) : base( input )
    {
    }

    public static implicit operator StorageServiceClient( BlobServiceClient _ ) => new( _ );
    public static implicit operator StorageServiceClient( TableServiceClient _ ) => new( _ );
    public static implicit operator StorageServiceClient( QueueServiceClient _ ) => new( _ );

    public static explicit operator BlobServiceClient? ( StorageServiceClient _ ) => _.IsT0 ? _.AsT0 : null;
    public static explicit operator TableServiceClient?( StorageServiceClient _ ) => _.IsT1 ? _.AsT1 : null;
    public static explicit operator QueueServiceClient?( StorageServiceClient _ ) => _.IsT2 ? _.AsT2 : null;

        public static InvalidCastException InvalidCastException<TServiceClient>( )
        => new InvalidCastException($"The underlying type of StorageServiceClient instance does not match the expected type of {typeof(TServiceClient).Name} ");
}
