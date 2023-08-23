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

public record ScheduledOrderRestQuery : RestClientJsonQuery, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public ScheduledOrderRestQuery( OperationContextID contextID , AutoOrderID scheduledOrderID , ExigoTypeID? scheduledOrderStatus )
    {
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;
        SendUrl = new ApiEndpoint( "autoorder" );
        QueryParams = new Dictionary<string , object>
        {
            [ nameof( GetAutoOrdersRequest.AutoOrderID ) ] = scheduledOrderID.Value ,
        };

        if( scheduledOrderStatus.HasValue )
            QueryParams.Add( nameof( GetAutoOrdersRequest.AutoOrderStatus), scheduledOrderStatus.Value.Value  );
    }
    public ScheduledOrderRestQuery( OperationContextID contextID , CustomerID userID,  ExigoTypeID? scheduledOrderStatus )
    {
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;

        SendUrl = new ApiEndpoint ( "autoorder" );
        QueryParams = new Dictionary<string , object>
        {
            [ nameof ( GetAutoOrdersRequest.CustomerID ) ] = userID.Value ,
        };

        if ( scheduledOrderStatus.HasValue )
            QueryParams.Add ( nameof ( GetAutoOrdersRequest.AutoOrderStatus ) , scheduledOrderStatus.Value.Value );
    }

    public static Func< ScheduledOrderRestQuery,IIntegrationsService , CancellationToken , Task<AutoOrderResponse?>> Find => async ( query ,service , token ) =>
    {
        var apiResponse = await GetApiResult( query, service, token );
        return apiResponse.AutoOrders.Length > 0 ? apiResponse.AutoOrders[0] : default;
    };
    public static Func<ScheduledOrderRestQuery , IIntegrationsService , CancellationToken , Task<List<AutoOrderResponse>>> Search => async ( query , service , token ) =>
    {
        var apiResponse = await GetApiResult( query, service, token );
        return apiResponse.AutoOrders.ToList();
    };
    static async Task<GetAutoOrdersResponse> GetApiResult( ScheduledOrderRestQuery query , IIntegrationsService service, CancellationToken cancellationToken )
    {
        var operationResult = await service.ExecuteIntegrationQuery<RestClientJsonQuery, GetAutoOrdersResponse>( query , cancellationToken );
        if( operationResult.TryPickT1( out var err , out _ ))
            query.OperationError = err.Error.Message;

        return operationResult.GetSingleOrFirstListItemResult() ?? new GetAutoOrdersResponse();
    }
}
