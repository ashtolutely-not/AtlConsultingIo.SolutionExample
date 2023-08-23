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

public record UserSiteSqlQuery : FindSqlRow, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public UserSiteSqlQuery( CustomerID customerID , OperationContextID contextID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        TableName = new SqlTableName ( "CustomerSites" );
        PrimaryKeyColumn = new ( "CustomerID" );
        RowId = new SqlRowID ( customerID.Value );
    }
    public UserSiteSqlQuery( WebAlias siteAlias , OperationContextID contextID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        TableName = new SqlTableName ( "CustomerSites" );
        PrimaryKeyColumn = new ( "WebAlias" );
        RowId = new SqlRowID ( siteAlias.Value );
    }

    public static Func<UserSiteSqlQuery, IIntegrationsService, CancellationToken , Task<UserSite?>> Execute =
        async( query, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<FindSqlRow,CustomerSite>( query, token );
            query.OperationError = operationResult.ErrorMessageOrDefault;

            UserSite? result = null;
            operationResult.Switch(
                    success => success.Switch(
                            single => result = UserSite( single ),
                            list => result = list.Count > 0 ? UserSite( list[0] ) : null,
                            notfound => { }
                        ),
                    err => query.OperationError = err.Error.Message
            );

            return result;
        };

    static UserSite UserSite( CustomerSite sqlResult )
    {
        return new UserSite ( )
        {
            UserId = new CustomerID ( sqlResult.CustomerId ) ,
            SiteAlias = sqlResult.WebAlias ,
            SiteEmail = sqlResult.Email ,
            SitePhone = sqlResult.Phone.HasValue ( ) ? sqlResult.Phone : sqlResult.Phone2 ,
            Url = new UserSiteUrl ( new WebAlias ( sqlResult.WebAlias ) )
        };
    }
}
