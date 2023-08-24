using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;




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
