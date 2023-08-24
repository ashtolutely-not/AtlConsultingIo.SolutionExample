using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;



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
