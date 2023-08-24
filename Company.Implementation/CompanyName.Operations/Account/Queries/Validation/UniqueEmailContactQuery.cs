using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Integrations.Exigo;


namespace CompanyName.Operations.Account;

public record UniqueEmailContactQuery : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public UniqueEmailContactQuery( OperationContextID contextID , EmailAddress contactEmail, ICompanyAccountType accountType )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        SearchProcedure = new("API_VerifyUniqueEmailContact");
        Params = new(new
        {
            CustomerTypeID = accountType.TypeId.Value,
            Email = contactEmail.Value
        });
        Convert = async ( record ) =>
        {
            if( record is null || record.IsDBNull(0) )
                return new SqlRowCountResult();

            var rowCount = record.GetValue(0) is int _count 
                            ? new SqlRowCountResult( _count ) 
                            : new SqlRowCountResult();
            return await Task.FromResult( rowCount ).ConfigureAwait(false);
        };        
    }

    public Func<UniqueEmailContactQuery, IIntegrationsService , AccountValidationOptions , CancellationToken, Task<Valid>> Execute => async( query ,service, options, token ) =>
    {
        var operationResult = await service.ExecuteIntegrationQuery<SearchSqlEntities,SqlRowCountResult>( this, token );
        query.OperationError = operationResult.ErrorMessageOrDefault;

        var rowCountResult = operationResult.GetSingleOrFirstListItemResult();
        return rowCountResult is not SqlRowCountResult _rowCount 
                ? options.IsEmailValidOnDatabaseError ? Valid.True : Valid.False
                : _rowCount.RecordCount > 0 ? Valid.False : Valid.True;

    };
}
