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

public record CustomerGroupsSqlQuery : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public CustomerGroupsSqlQuery( CustomerID customerID , OperationContextID contextID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        SearchProcedure = new("API_CustomerGroupsQuery");
        Params = new( new { CustomerID = customerID.Value });
        Convert = async(record) =>
        {
            if( record is null || record.IsDBNull(0) )
                return await Task.FromResult(new CommerceCloudCustomerGroup());

            var value = record.GetString(0);
            return await Task.FromResult(new CommerceCloudCustomerGroup{ GroupID = value });   
        };
    }

    public static Func<CustomerGroupsSqlQuery, IIntegrationsService, CancellationToken, Task<List<CommerceCloudCustomerGroup>>> Execute = 
        async( query, integrations, token ) =>
        {
            var operationResult = await integrations.ExecuteIntegrationQuery<SearchSqlEntities,CommerceCloudCustomerGroup>( query, token );

            List<CommerceCloudCustomerGroup> result = new();
            operationResult.Switch(
                    success => success.Switch( 
                            single => result.Add(single),
                            list => result = list,
                            notfound => { }
                        ),
                    err => query.OperationError = err.Error.Message);

            return result;
        };
}
