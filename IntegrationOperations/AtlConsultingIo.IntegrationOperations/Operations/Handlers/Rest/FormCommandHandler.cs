using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

internal class FormCommandHandler : IIntegrationCommand<RestClientFormCommand>
{
    private readonly HttpSendHandler _factory;
    private readonly IValidator<RestClientFormCommand> _validator;

    public FormCommandHandler( HttpSendHandler resultFactory , IValidator<RestClientFormCommand> validator )
    {
        _factory = resultFactory;
        _validator = validator;
    }

    public async Task Execute(
        RestClientFormCommand request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace( 
                request.Key, 
                request.ContextID, 
                typeof(FormCommandHandler)
            );

        _validator.ValidateAndThrow( request );
        HttpRequestMessage httpRequest = new ()
        {
            Method = HttpMethod.Post,
            RequestUri = !string.IsNullOrEmpty(request.SendUrl) ? new Uri( request.SendUrl, UriKind.Relative ) : null,
            Content = request.FormContent.GetEncodedForm()
        };

        HttpSendState state = new (request.Key, request.ContextID , httpRequest);
        state = await _factory.SendAsync( state , cancellationToken );
        if ( state.HttpResponse is null || !state.HttpResponse.Has2xxStatus() || state.SendException is not null )
            throw new HttpSendException( state );

        logger.OperationEndTrace( 
                request.Key, 
                request.ContextID, 
                typeof(FormCommandHandler)
            );
    }


}
