using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations.Exigo;



namespace CompanyName.Operations.Account;

public record UniqueTaxIDValidationQuery : SearchSqlEntities, IIntegrationOperation
{
    public string? OperationError { get; set; }
    public UniqueTaxIDValidationQuery( OperationContextID contextID , IncomeTaxID taxID , CountryCode taxCountry )
    {
        Key = ExigoReplicatedDbKey.Instance;
        ContextID = contextID;

        SearchProcedure = new("API_VerifyUniqueTaxId");
        Params = new(new
        {
            TaxId = taxID.Value,
            TaxCountry = taxCountry.Value
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

    public Func<UniqueTaxIDValidationQuery , IIntegrationsService , AccountValidationOptions , CancellationToken , Task<Valid>> Execute => async ( query , service , options , token ) =>
    {
        var operationResult = await service.ExecuteIntegrationQuery<SearchSqlEntities,SqlRowCountResult>( this, token );
        query.OperationError = operationResult.ErrorMessageOrDefault;

        var rowCountResult = operationResult.GetSingleOrFirstListItemResult();
        return rowCountResult is not SqlRowCountResult _rowCount
                ? options.IsTaxIdValidOnDatabaseError ? Valid.True : Valid.False
                : _rowCount.RecordCount > 0 ? Valid.False : Valid.True;

    };
}
