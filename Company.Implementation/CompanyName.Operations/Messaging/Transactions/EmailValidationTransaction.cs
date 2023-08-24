using AtlConsultingIo.IntegrationOperations;

using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Integrations.SendGridApi;



namespace CompanyName.Operations.Messaging;

public record EmailValidationTransaction : RestClientJsonTransaction, IIntegrationOperation
{
    private readonly EmailAddress _email;
    public string? OperationError { get; set; } 
    public EmailValidationTransaction( OperationContextID contextID, EmailAddress emailAddress  )
    {
        Key = SendGridValidationApiKey.Instance;
        ContextID = contextID;

        HttpMethod = HttpMethod.Post;
        SendUrl = new ApiEndpoint("validations/email");
        JsonData = new SGEmailValidationRequest
        {
            Email = emailAddress.Value,
            Source = contextID.Value
        };

        _email = emailAddress;
    }

    public static Func<EmailValidationTransaction,IIntegrationsService, CancellationToken, Task<SGEmailValidationResult?>> Execute => 
        async( transactionReq ,service, token ) =>
        {
            var operationResult = await service.ExecuteIntegtrationTransaction<RestClientJsonTransaction, SGEmailValidationResult>( transactionReq, token );
            
            SGEmailValidationResult? validationResult = null;
            operationResult.Switch(
                        success => validationResult = success.Result,
                        err => transactionReq.OperationError = err.Error.Message 
                    );

            return validationResult;
        };


}
