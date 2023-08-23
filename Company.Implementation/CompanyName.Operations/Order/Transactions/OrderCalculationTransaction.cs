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



namespace CompanyName.Operations.Order;

public record OrderCalculationTransaction : RestClientJsonTransaction, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public OrderCalculationTransaction( OperationContextID contextID , CalculateOrderRequest requestData )
    {
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;

        HttpMethod = HttpMethod.Post;
        SendUrl = new ApiEndpoint( "orders/calculate" );
        JsonData = requestData;
    }
    public static Func<OrderCalculationTransaction,IIntegrationsService , CancellationToken , Task<CalculateOrderResponse?>> Execute => async ( transactionReq , service , token ) =>
    {
        var operationResult = await service.ExecuteIntegtrationTransaction<RestClientJsonTransaction,CalculateOrderResponse>( transactionReq, token );
        
        CalculateOrderResponse? response = null;
        operationResult.Switch( success => response = success.Result, err => transactionReq.OperationError = err.Error.Message );

        return response;
    };
}
