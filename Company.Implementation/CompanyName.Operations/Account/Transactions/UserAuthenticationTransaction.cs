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




namespace CompanyName.Operations.Account;
public record UserAuthenticationTransaction : RestClientJsonTransaction, IIntegrationOperation
{
    public Username Username { get; init; }
    public string Password { get; init; } = String.Empty;

    public CustomerID? CustomerID { get; set; }
    public string? OperationError { get; set; } 
    public UserAuthenticationTransaction( string username , string password , OperationContextID contextID )
    {
        Username = new( username );
        Password = password;

        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;

        SendUrl = new ApiEndpoint( "customers/authenticate" );
        HttpMethod = HttpMethod.Post;

        JsonData = new AuthenticateCustomerRequest
        {
            LoginName = username ,
            Password = password
        };
    }

    public static Func<UserAuthenticationTransaction,IIntegrationsService,CancellationToken,Task<UserAuthenticationTransaction>> Execute =
        async( transaction, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegtrationTransaction<RestClientJsonTransaction,AuthenticateCustomerResponse>( transaction, token );
            operationResult.Switch(
                        success => transaction.CustomerID = new CustomerID( success.Result.CustomerID ),
                        err => transaction.OperationError = err.Error.Message
                    );

            return transaction;
        };

}
