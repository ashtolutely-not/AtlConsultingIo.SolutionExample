using AtlConsultingIo.IntegrationOperations;

using AutoMapper;

using CompanyName.Core.Entities;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;



namespace CompanyName.Operations.Account;

public record ExigoApiUserQuery : RestClientJsonQuery
{
    public string OperationError { get; set; } = String.Empty;

    public ExigoApiUserQuery( OperationContextID contextID , CustomerID customerID )
        : this ( contextID ) => QueryParams = new Dictionary<string , object> { [ nameof ( GetCustomersRequest.CustomerID ) ] = customerID.Value };
    public ExigoApiUserQuery( OperationContextID contextID , CustomerID customerID , EnrollerSearchOptions searchOptions )
        : this ( contextID ) => QueryParams = new Dictionary<string , object>
        {
            [ nameof ( GetCustomersRequest.CustomerID ) ] = customerID.Value ,
            [ nameof ( GetCustomersRequest.CustomerTypes ) ] = searchOptions.CustomerTypeFilter ,
            [ nameof ( GetCustomersRequest.CustomerStatuses ) ] = searchOptions.CustomerStatusFilter
        };
    public ExigoApiUserQuery( OperationContextID contextID , Username username , EnrollerSearchOptions searchOptions )
        : this ( contextID ) => QueryParams = new Dictionary<string , object>
        {
            [ nameof ( GetCustomersRequest.LoginName ) ] = username.Value ,
            [ nameof ( GetCustomersRequest.CustomerTypes ) ] = searchOptions.CustomerTypeFilter ,
            [ nameof ( GetCustomersRequest.CustomerStatuses ) ] = searchOptions.CustomerStatusFilter
        };
    public ExigoApiUserQuery( OperationContextID contextID , EmailAddress email , EnrollerSearchOptions searchOptions )
        : this ( contextID ) => QueryParams = new Dictionary<string , object>
        {
            [ nameof ( GetCustomersRequest.Email ) ] = email.Value ,
            [ nameof ( GetCustomersRequest.CustomerTypes ) ] = searchOptions.CustomerTypeFilter ,
            [ nameof ( GetCustomersRequest.CustomerStatuses ) ] = searchOptions.CustomerStatusFilter
        };
    private ExigoApiUserQuery( OperationContextID contextID )
    {
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;

        SendUrl = new ApiEndpoint( "customers" );
    }

    public static Func<ExigoApiUserQuery,IIntegrationsService, CancellationToken, Task<CustomerResponse?>> FindCustomer =
        async( apiQuery, service, token ) =>
        {
            var res = await service.ExecuteIntegrationQuery<RestClientJsonQuery,GetCustomersResponse>( apiQuery, token );
            var apiResponse = GetApiResponse( res );

            if( res.TryPickT1( out var err , out _ ))
                apiQuery.OperationError = err.Error.Message;

            return apiResponse.Customers.FirstOrDefault();
        };
    public static Func<ExigoApiUserQuery,IIntegrationsService,CancellationToken,Task<List<CustomerResponse>>> SearchCustomers = 
        async ( apiQuery, service, token ) =>
        {
            var res = await service.ExecuteIntegrationQuery<RestClientJsonQuery,GetCustomersResponse>( apiQuery, token );
            var apiResponse = GetApiResponse( res );

            if( res.TryPickT1( out var err , out _ ))
                apiQuery.OperationError = err.Error.Message;

            return apiResponse.Customers.ToList();
        };
    public static Func<ExigoApiUserQuery , IIntegrationsService , IMapper , CancellationToken , Task<AccountResult?>> FindAccount =
        async ( apiQuery , service , mapper , token ) =>
        {
            var customer = await FindCustomer( apiQuery ,service, token );
            return customer is CustomerResponse _customer ? mapper.Map<AccountResult>( _customer ) : null;
        };
    public static Func<ExigoApiUserQuery,IIntegrationsService , IMapper , CancellationToken , Task<List<AccountResult>>> SearchAccounts =
        async ( apiQuery , service , mapper , token ) =>
        {
            var customers = await SearchCustomers( apiQuery, service, token );
            if( !customers.Any() )
                return new List<AccountResult>(0);

            return customers.Select( c => mapper.Map<AccountResult>(c)).ToList();
        };

    private static GetCustomersResponse GetApiResponse( QueryOperationResult<GetCustomersResponse> queryResult )
    {
        var response = queryResult.GetSingleOrFirstListItemResult();
        return response is null ? new GetCustomersResponse ( ) : response;
    }
}
