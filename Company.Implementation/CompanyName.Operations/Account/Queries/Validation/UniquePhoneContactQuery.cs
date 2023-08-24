using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Operations.Account;

public record UniquePhoneContactValidationQuery : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public UniquePhoneContactValidationQuery( OperationContextID contextID , PhoneNumber phoneContact, ICompanyAccountType accountType )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        SearchProcedure = new("API_VerifyUniquePhoneContact");
        Params = new(new
        {
            CustomerTypeID = accountType.TypeId.Value,
            PhoneNumber = phoneContact.Value
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
    public Func<UniquePhoneContactValidationQuery , IIntegrationsService , AccountValidationOptions , CancellationToken , Task<Valid>> Execute => async ( query , service , options , token ) =>
    {
        var operationResult = await service.ExecuteIntegrationQuery<SearchSqlEntities,SqlRowCountResult>( this, token );
        query.OperationError = operationResult.ErrorMessageOrDefault;

        var rowCountResult = operationResult.GetSingleOrFirstListItemResult();
        return rowCountResult is not SqlRowCountResult _rowCount
                ? options.IsPhoneNumberValidOnDatabaseError ? Valid.True : Valid.False
                : _rowCount.RecordCount > 0 ? Valid.False : Valid.True;

    };
}
