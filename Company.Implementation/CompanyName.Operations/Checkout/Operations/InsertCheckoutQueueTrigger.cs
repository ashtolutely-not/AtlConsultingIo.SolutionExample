using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using AtlConsultingIo.IntegrationOperations;


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
