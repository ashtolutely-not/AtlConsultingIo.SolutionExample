using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Operations.Product;

public record EnrollmentKitItemSearch : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public EnrollmentKitItemSearch( )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = new ( );
        SearchProcedure = new SqlStoredProcedure ( "API_EnrollmentKitQuery" );
        Convert = async ( dataRow ) =>
        {
            if ( dataRow is null || dataRow.IsDBNull ( 0 ) )
                return new EnrollmentKitItemCode ( );
            return await Task.FromResult ( new EnrollmentKitItemCode ( dataRow.GetString ( 0 ) ) );
        };
    }

    public static Func<EnrollmentKitItemSearch, IIntegrationsService, CancellationToken, Task<List<EnrollmentKitItemCode>>> Execute =
        async( query, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<SearchSqlEntities, EnrollmentKitItemCode>( query, token );

            List<EnrollmentKitItemCode> result = new();
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
