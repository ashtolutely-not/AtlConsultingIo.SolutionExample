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

public record UserPointAccountRestQuery : RestClientJsonQuery, IIntegrationOperation
{

    public CustomerID UserID { get; init; }
    public PointAccountID PointAccountID { get; init; }
    public UserPointAccount? Result { get; init; }
    public string? OperationError { get; set; } 

    public UserPointAccountRestQuery( CustomerID userID, PointAccountID accountID )
    {
        UserID = userID;
        PointAccountID = accountID;

        Key = ExigoEntitiesApiKey.Instance;
        SendUrl = new ApiEndpoint("point/account");
        QueryParams = new Dictionary<string, object>
        {
            ["customerID"] = UserID.Value,
            ["pointAccountID"] = PointAccountID.Value
        };
        Deserialize = async( response ) =>
        {
            var apiResponse = await response.ConvertAndThrow<GetPointAccountResponse>();
            return new UserPointAccount{ PointAccountID = accountID , AccountBalance = apiResponse.Balance };
        };
    }

    public static Func<UserPointAccountRestQuery, IIntegrationsService, CancellationToken, Task<UserPointAccount?>> Execute = async( apiQuery, service, token ) =>
    {
        var operationResult = await service.ExecuteIntegrationQuery<RestClientJsonQuery,UserPointAccount>( apiQuery, token );


        UserPointAccount? result = null;
        operationResult.Switch(
                success => success.Switch(
                    single => result = single,
                    list => result = list.Count > 0 ? list[0] : null ,
                    notfound => { }
                ),
                err => apiQuery.OperationError = err.Error.Message
            );

        return result;
    };

}


