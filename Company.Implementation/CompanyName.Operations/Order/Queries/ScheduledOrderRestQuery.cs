using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;



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
