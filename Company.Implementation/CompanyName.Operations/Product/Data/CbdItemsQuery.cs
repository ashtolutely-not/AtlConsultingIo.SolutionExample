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



namespace CompanyName.Operations.Product;
public record CbdItemSearch : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public CbdItemSearch( )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = new();
        SearchProcedure = new SqlStoredProcedure( "API_CbdItemsQuery" );
        Convert = async ( dataRow ) => 
        {
            if( dataRow is null || dataRow.IsDBNull(0) )
                return new CbdItemCode();
            return await Task.FromResult( new CbdItemCode ( dataRow.GetString ( 0 ) ) );
        };
    }

    public static Func<CbdItemSearch, IIntegrationsService, CancellationToken, Task<List<CbdItemCode>>> Execute = 
        async( query, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<SearchSqlEntities, CbdItemCode>( query, token );

            List<CbdItemCode> result = new();
            operationResult.Switch(
                        success => success.Switch(
                                single => result.Add( single ),
                                list => result = list,
                                notfound => { }
                            ),
                        err => query.OperationError = err.Error.Message
                    );

            return result;
        };

}
