using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Integrations.Exigo;



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
