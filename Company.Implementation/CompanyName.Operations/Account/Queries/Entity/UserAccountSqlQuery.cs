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

public record UserAccountSqlQuery : FindSqlRow, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public UserAccountSqlQuery( CustomerID customerID , OperationContextID contextID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        TableName = new SqlTableName("Customers");
        RowId = new SqlRowID( customerID.Value );
        PrimaryKeyColumn = new SqlPrimaryKeyColumn("CustomerID");
    }

    public static Func<UserAccountSqlQuery, IIntegrationsService, IMapper, CancellationToken, Task<AccountResult?>> FindAccount = 
        async( query, service, mapper, token ) =>
        {
            Customer? customer = await FindCustomer!( query, service, token );
            if( customer is null )
                return null;

            return mapper.Map<AccountResult>( customer );
        };

    public static Func<UserAccountSqlQuery, IIntegrationsService, CancellationToken ,Task<Customer?>> FindCustomer = 
        async( query, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<FindSqlRow,Customer>(query, token);
            query.OperationError = operationResult.ErrorMessageOrDefault;

            return operationResult.GetSingleOrFirstListItemResult();
        };
}
