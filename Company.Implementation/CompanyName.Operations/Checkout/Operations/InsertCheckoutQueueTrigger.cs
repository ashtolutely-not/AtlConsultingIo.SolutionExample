using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Integrations;


namespace CompanyName.Operations.Checkout;

public record InsertCheckoutQueueTrigger : InsertQueueItem
{
    public InsertCheckoutQueueTrigger( CheckoutState state, string queueName )
    {
        Key = AppStorageKey.Instance;
        ContextID = state.OperationContextID;
        QueueName = new StorageQueueName( queueName );
        QueueItem = new
        {
            EventFileName = state.GetBlobName().Value
        };
    }
}
