
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

internal class JsonCommandHandler : IIntegrationCommand<RestClientJsonCommand>
{
    private readonly HttpSendHandler _factory;
    private readonly IValidator<RestClientJsonCommand> _validator;

    public JsonCommandHandler( HttpSendHandler resultFactory , IValidator<RestClientJsonCommand>  validator )
    {
        _factory = resultFactory;
        _validator = validator;
    }

    public async Task Execute(
        RestClientJsonCommand request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken )
    {
        logger.OperationStartTrace( 
                request.Key, 
                request.ContextID, 
                typeof(JsonCommandHandler)
            );

        _validator.ValidateAndThrow( request );
        RestClientConfiguration options = clientConfiguration.AsRestOptions;
        string content = request.Serialize is not null ?
                                await request.Serialize( request.JsonData ) :
                                JsonConvert.SerializeObject( request.JsonData );

        HttpRequestMessage httpRequest = new ()
        {
            Method = request.HttpMethod,
            RequestUri = !string.IsNullOrEmpty(request.SendUrl) ? new Uri( request.SendUrl, UriKind.Relative ) : null,
            Content = new StringContent(
                                content,
                                Encoding.UTF8,
                                HttpContentType.Json
                            )
        };

        HttpSendState state = new ( request.Key, request.ContextID , httpRequest);
        state = await _factory.SendAsync( state , cancellationToken );
        if ( state.SendException is not null || state.HttpResponse is null || !state.HttpResponse.Has2xxStatus() )
            throw new HttpSendException( state );

        logger.OperationEndTrace( 
                request.Key, 
                request.ContextID, 
                typeof(JsonCommandHandler)
            );
    }

}
