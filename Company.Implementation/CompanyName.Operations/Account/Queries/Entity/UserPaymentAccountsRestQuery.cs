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

using AutoMapper;





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
