using AtlConsultingIo.IntegrationOperations;

using AutoMapper;

using CompanyName.Core;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;





namespace CompanyName.Operations.Account;

public record UserPaymentAccountsRestQuery : RestClientJsonQuery, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public UserPaymentAccountsRestQuery( CustomerID customerID , OperationContextID contextID )
    {
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;
        SendUrl = new ApiEndpoint( "account" );
        QueryParams = new Dictionary<string , object>
        {
            [ "customerID" ] = customerID.Value
        };
    }

    public static Func<UserPaymentAccountsRestQuery, IIntegrationsService, IMapper, CancellationToken, Task<List<UserPaymentAccount>>> Execute =
        async( query, service, mapper, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<RestClientJsonQuery, GetCustomerBillingResponse>( query , token );
            
            List<UserPaymentAccount> result = new();
            operationResult.Switch(
                    success => success.Switch(
                            single => result.AddRange( mapper.Map<IEnumerable<UserPaymentAccount>>( single )),
                            list => list.ForEach( itm => result.AddRange(mapper.Map<IEnumerable<UserPaymentAccount>>( itm ))),
                            notfound => { }
                        ),
                    err => query.OperationError = err.Error.Message
                );

            return result;
        };


}
