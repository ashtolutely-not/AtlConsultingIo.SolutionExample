using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;




namespace CompanyName.Operations.Account;

public record UserSiteRestQuery : RestClientJsonQuery, IIntegrationOperation
{
    public string? OperationError { get; set; } = string.Empty;
    public UserSiteRestQuery( OperationContextID contextID, CustomerID customerID  ) : this( contextID )
    {
        QueryParams = new Dictionary<string , object>
        {
            [ "customerID" ] = customerID.Value
        };
    }
    public UserSiteRestQuery( OperationContextID contextID , WebAlias alias ) : this( contextID )
    {
        QueryParams = new Dictionary<string, object>
        {
            ["webAlias"] = alias.Value
        };
    }
    private UserSiteRestQuery( OperationContextID contextID )
    {
        Key = ExigoEntitiesApiKey.Instance;
        ContextID = contextID;
        SendUrl = new ApiEndpoint( "customers/site" );
    }

    public static Func<UserSiteRestQuery, IIntegrationsService, CancellationToken , Task<UserSite?>> Execute = 
        async( query, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<RestClientJsonQuery,GetCustomerSiteResponse>( query, token );
            query.OperationError = operationResult.ErrorMessageOrDefault;

            var apiResponse = operationResult.GetSingleOrFirstListItemResult();
            return apiResponse is not GetCustomerSiteResponse _response ? null :
            new UserSite
            {
                UserId = new CustomerID( _response.CustomerID ),
                SiteAlias = _response.WebAlias ,
                SiteEmail = _response.Email ,
                SitePhone = _response.Phone.HasValue() ? _response.Phone : _response.Phone2,
                Url = new UserSiteUrl( new WebAlias(_response.WebAlias) )
            };
        };
}
