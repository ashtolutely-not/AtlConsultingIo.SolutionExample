using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Operations.Account;

public record UniqueUsernameValidationQuery: SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public UniqueUsernameValidationQuery( OperationContextID contextID , Username username )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        SearchProcedure = new("API_VerifyUniqueUsername");
        Params = new(new
        {
            LoginName = username.Value
        });
        Convert = async ( record ) =>
        {
            if( record is null || record.IsDBNull(0) )
                return new SqlRowCountResult(0);

            var rowCount = record.GetValue(0) is int _count 
                            ? new SqlRowCountResult( _count ) 
                            : new SqlRowCountResult(0);
            return await Task.FromResult( rowCount ).ConfigureAwait(false);
        };        
    }
    public Func<UniqueUsernameValidationQuery , IIntegrationsService , AccountValidationOptions , CancellationToken , Task<Valid>> Execute => async ( query , service , options , token ) =>
    {
        var operationResult = await service.ExecuteIntegrationQuery<SearchSqlEntities,SqlRowCountResult>( this, token );
        query.OperationError = operationResult.ErrorMessageOrDefault;

        var rowCountResult = operationResult.GetSingleOrFirstListItemResult();
        return rowCountResult is not SqlRowCountResult _rowCount
                ? options.IsUsernameValidOnDatabaseError ? Valid.True : Valid.False
                : _rowCount.RecordCount > 0 ? Valid.False : Valid.True;

    };
}
