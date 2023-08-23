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
