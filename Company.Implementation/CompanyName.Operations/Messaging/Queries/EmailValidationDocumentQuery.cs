using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core.Entities;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.SendGridApi;



namespace CompanyName.Operations.Messaging;

public record EmailValidationDocumentQuery : FindTableDocument
{
    public EmailValidationDocumentQuery(
        AppStorageKey integrationName ,
        OperationContextID contextID ,
        EmailAddress emailAddress ,
        StorageTableName tableName )
    {
        Key = integrationName;
        ContextID = contextID;

        TableName = tableName;
        PartitionKey = nameof(SGEmailValidationResult);
        RowKey = emailAddress.Value;
    }

    public static Func<EmailValidationDocumentQuery,IIntegrationsService,CancellationToken, Task<SGEmailValidationResult?>> GetResultOrDefault =>
        async( query, service, token ) =>
        {
            var operationResult = await service.ExecuteIntegrationQuery<FindTableDocument,SGEmailValidationResult>( query, token );    
            return operationResult.GetSingleOrFirstListItemResult();
        };
}
