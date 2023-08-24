using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;



namespace CompanyName.Operations.Account;

public record UserPointAccountTransaction : RestClientJsonTransaction, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public IOrderPointTransaction Transaction { get; set; }
    public UserPointAccountTransaction( PointAccountPayment orderPayment , OperationContextID contextID )
    {
        Transaction = orderPayment;
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;

        HttpMethod = HttpMethod.Post;
        SendUrl = new ApiEndpoint ( "point" );
        JsonData = new CreatePointTransactionRequest
        {
            PointAccountID = orderPayment.PointAccountID ,
            CustomerID = orderPayment.UserID ,
            Amount = orderPayment.TransactionAmount ,
            Reference = orderPayment.TransactionReference ,
            PointTransactionTy = ExigoConfiguration.CheckoutSettings.Instance.TypeIDs.PointRedemptionTransactionType
        };
    }
    public UserPointAccountTransaction( PointPaymentReversal paymentReversal , OperationContextID contextID )
    {
        Transaction = paymentReversal;
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;
        HttpMethod = HttpMethod.Post;
        SendUrl = new ApiEndpoint ( "point" );
        JsonData = new CreatePointTransactionRequest
        {
            PointAccountID = paymentReversal.PointAccountID ,
            CustomerID = paymentReversal.UserID ,
            Amount = paymentReversal.TransactionAmount ,
            Reference = paymentReversal.TransactionReference ,
            PointTransactionTy = ExigoConfiguration.CheckoutSettings.Instance.TypeIDs.PointAdjustmentTransactionType
        };

    }

    public static Func<UserPointAccountTransaction,IIntegrationsService, CancellationToken, Task<IOrderPointTransaction>> Execute = async( operation, service, token ) =>
    {
        var operationResult = await service.ExecuteIntegtrationTransaction<RestClientJsonTransaction,CreatePointTransactionResponse>( operation, token );
        operationResult.Switch(
                    success => operation.Transaction.TransactionID = new ExigoEntityID( success.Result.TransactionID ),
                    error => operation.OperationError = error.Error.Message
                );

        return operation.Transaction;
    };
}


/* Exigo API Behavior Notes 
    -- The Transaction Type has zero impact on if this increments/decrements the account
    -- While there is a public constructor on the reversal type definition for serialization purposes,
    -- It is recommended to use the construtor that takes the payment transaction as a param to ensure expected behavior.
 */
