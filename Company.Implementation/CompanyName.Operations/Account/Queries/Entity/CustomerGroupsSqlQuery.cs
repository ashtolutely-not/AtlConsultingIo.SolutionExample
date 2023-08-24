using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;


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
