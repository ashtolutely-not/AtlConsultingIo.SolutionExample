using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Operations.Account;

public record EnrollerAccountSqlSearch : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public EnrollerAccountSqlSearch( EnrollerGeoSearchParams geoSearch , OperationContextID contextID )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;
        SearchProcedure = new("API_EnrollerGeoSearch");
        Params = new ( geoSearch.QueryParams() );
    }

    // TODO
    public static Func<EnrollerAccountSqlSearch, IIntegrationsService, CancellationToken, Task<List<EnrollerAccount>>> Execute = 
        async( searchRequest, service, token ) =>
        {
            return await Task.FromResult( new List<EnrollerAccount>() );
        };
}
