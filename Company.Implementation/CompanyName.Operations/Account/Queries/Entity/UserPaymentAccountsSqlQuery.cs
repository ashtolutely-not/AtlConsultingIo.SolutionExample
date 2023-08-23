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

public record UserPaymentAccountsSqlQuery : FindSqlRow, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public UserPaymentAccountsSqlQuery( CustomerID customerID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        TableName = new SqlTableName("CustomerAccounts");
        RowId = new SqlRowID( customerID.Value );
        PrimaryKeyColumn = new SqlPrimaryKeyColumn("CustomerID");
    }

    public static Func<UserPaymentAccountsSqlQuery, IIntegrationsService, IMapper, CancellationToken, Task<List<UserPaymentAccount>>> Execute =
        async( query, service, mapper, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<FindSqlRow,CustomerAccount>( query , token);
            var dbResult = operationResult.GetSingleOrFirstListItemResult();
            query.OperationError = operationResult.ErrorMessageOrDefault;
            return dbResult is not null ? mapper.Map<IEnumerable<UserPaymentAccount>>( dbResult ).ToList() : new List<UserPaymentAccount>();
        };
}
