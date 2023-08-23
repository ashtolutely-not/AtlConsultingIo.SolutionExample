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

public record SalesOrderRestQuery : RestClientJsonQuery, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    //TODO: this can be an option
    private readonly DateTime defaultDateFilter = DateTime.UtcNow.AddYears(-2);
    public SalesOrderRestQuery( OperationContextID contextID , OrderID orderID , bool includeCustomerResult, DateTime? startDateFilter )
    {
        DateTime _start = startDateFilter.HasValue && startDateFilter.Value < DateTime.UtcNow
                            ? startDateFilter.Value : defaultDateFilter;

        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;

        SendUrl = new ApiEndpoint( "orders" );
        QueryParams = new Dictionary<string , object>
        {
            [ nameof( GetOrdersRequest.OrderID ) ] = orderID.Value ,
            [ nameof( GetOrdersRequest.OrderDateStart ) ] = _start
        };
        if( includeCustomerResult )
            QueryParams.Add( nameof(GetOrdersRequest.ReturnCustomer), true );
    }
    public SalesOrderRestQuery( OperationContextID contextID , CartID cartID , bool includeCustomerResult, DateTime? startDateFilter )
    {
        DateTime _start = startDateFilter.HasValue && startDateFilter.Value < DateTime.UtcNow
                            ? startDateFilter.Value : defaultDateFilter;

        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;
        SendUrl = new ApiEndpoint( "orders" );
        QueryParams = new Dictionary<string , object>
        {
            [ ExigoCustomOrderFields.CartID ] = cartID.Value ,
            [ nameof( GetOrdersRequest.OrderDateStart ) ] = _start
        };
        if( includeCustomerResult )
            QueryParams.Add( nameof(GetOrdersRequest.ReturnCustomer), true );
    }

    public static Func<SalesOrderRestQuery , IIntegrationsService , CancellationToken , Task<OrderResponse?>> Find => async ( query , service , token ) =>
    {
        var apiResponse = await GetApiResult( query, service, token );
        return apiResponse.Orders.Length > 0 ? apiResponse.Orders[ 0 ] : default;
    };
    public static Func<SalesOrderRestQuery , IIntegrationsService , CancellationToken , Task<List<OrderResponse>>> Search => async ( query , service , token ) =>
    {
        var apiResponse = await GetApiResult( query, service, token );
        return apiResponse.Orders.ToList ( );
    };
    static async Task<GetOrdersResponse> GetApiResult( SalesOrderRestQuery query , IIntegrationsService service , CancellationToken cancellationToken )
    {
        var operationResult = await service.ExecuteIntegrationQuery<RestClientJsonQuery, GetOrdersResponse>( query , cancellationToken );
        if ( operationResult.TryPickT1 ( out var err , out _ ) )
            query.OperationError = err.Error.Message;

        return operationResult.GetSingleOrFirstListItemResult ( ) ?? new GetOrdersResponse ( );
    }

}
