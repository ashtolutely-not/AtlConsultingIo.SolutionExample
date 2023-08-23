// TODO: This should go in an Commands project, then move aggregate operations into a TotalLife.IntegrationOperations project
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



namespace CompanyName.Operations.Messaging;

public record SaveEmailValidationDocument : UpsertTableDocument, IIntegrationOperation
{
    public string? OperationError { get; set; } 
    public SaveEmailValidationDocument( AppStorageKey storageIntegrationName, OperationContextID contextID, StorageTableName tableName, SGEmailValidationResult validationResult )
    {
        Key = storageIntegrationName;
        ContextID = contextID;

        TableName = tableName;
        UpdateMode = Azure.Data.Tables.TableUpdateMode.Replace;
        EntityData = new( partitionKey: nameof(SGEmailValidationResult ), rowKey: validationResult.Email )
        {
            { nameof(SGEmailValidationResult.IsValid), validationResult.IsValid },
            { nameof(SGEmailValidationResult.Score), validationResult.Score },
            { nameof(SGEmailValidationResult.Email), validationResult.Email },
            { nameof(SGEmailValidationResult.LocalAddress), validationResult.LocalAddress},
            { nameof(SGEmailValidationResult.EmailDomain), validationResult.EmailDomain },
            { nameof(SGEmailValidationResult.EmailAddressIP), validationResult.EmailAddressIP },
            { nameof(SGEmailValidationResult.Suggestion), validationResult.Suggestion },
            { nameof(SGEmailValidationResult.Source), validationResult.Source },
            { nameof(SGEmailValidationResult.Results), validationResult.Results },
        };
    }

    public static Func<SaveEmailValidationDocument , IIntegrationsService,CancellationToken,Task> Execute => async( command, service,token) =>
    {
        var result = await service.ExecuteIntegrationCommand<UpsertTableDocument>( command, token );
        result.Switch(
                success => { },
                err => command.OperationError = err.Error.Message
            );
    };
}
