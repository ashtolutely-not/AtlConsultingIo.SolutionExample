

using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public class FormTransactionHandler : IIntegrationTransaction<RestClientFormTransaction>
{
    private readonly HttpSendHandler _factory;
    private readonly IValidator<RestClientFormTransaction> _validator;
    public FormTransactionHandler( HttpSendHandler resultFactory , IValidator<RestClientFormTransaction> validator  )
    {
        _factory = resultFactory;
        _validator = validator;
    }

    public async Task<TransactionSuccess<TResult>> Execute<TResult>(
        RestClientFormTransaction request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class,new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( FormTransactionHandler )
            );

        _validator.ValidateAndThrow( request );
        HttpRequestMessage httpRequest = new ()
        {
            Method = HttpMethod.Post,
            RequestUri = !string.IsNullOrEmpty(request.SendUrl) ? new Uri( request.SendUrl, UriKind.Relative ) : null,
            Content = request.FormContent.GetEncodedForm()
        };

        HttpSendState state = new (request.Key, request.ContextID, httpRequest);
        state = await _factory.SendAsync( state , cancellationToken );
        if ( state.HttpResponse is not HttpResponseMessage _httpResponse || !_httpResponse.Has2xxStatus() || state.SendException is not null )
            throw new HttpSendException( state );

        var anonResult = await request.Convert( state.HttpResponse );
        var typed = anonResult is not TResult _result
                    ? throw new InvalidCastException( $"Value returned by {nameof( FindJsonBlob )}.{nameof( FindJsonBlob.Convert )} cannot be cast to expected return type of {( typeof( TResult ).Name )}" )
                    : _result;

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( FormTransactionHandler )
            );

        return new TransactionSuccess<TResult>( typed );
    }


}
