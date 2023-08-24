using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;
public class JsonTransactionHandler : IIntegrationTransaction<RestClientJsonTransaction>
{
    private readonly HttpSendHandler _factory;
    private readonly IValidator<RestClientJsonTransaction> _validator;
    public JsonTransactionHandler( HttpSendHandler resultFactory , IValidator<RestClientJsonTransaction> validator )
    {
        _factory = resultFactory;
        _validator = validator;
    }

    public async Task<TransactionSuccess<TResult>> Execute<TResult>(
        RestClientJsonTransaction request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class,new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( JsonTransactionHandler )
            );

        _validator.ValidateAndThrow( request );
        RestClientConfiguration options = clientConfiguration.AsRestOptions;
        string content = request.Serialize is not null ? 
                            await request.Serialize(request.JsonData) :
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

        HttpSendState state = new (request.Key, request.ContextID , httpRequest);
        state = await _factory.SendAsync( state , cancellationToken );
        if ( state.HttpResponse is not HttpResponseMessage _httpResponse || !_httpResponse.Has2xxStatus() || state.SendException is not null )
            throw new HttpSendException( state );

        var result = request.Deserialize is not null 
                    ? await GetResult<TResult>( state.HttpResponse!, request.Deserialize )
                    : await GetResult<TResult>( state.HttpResponse! );

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( JsonTransactionHandler )
            );

        return new TransactionSuccess<TResult>(result);
    }

    private static async Task<TResult> GetResult<TResult>( HttpResponseMessage response, Func<HttpResponseMessage,Task<object>> deserialize )
        where TResult : class,new()
    {
        var anon = await deserialize(response);
        return anon is not TResult _result
                ? throw new InvalidCastException( $"Value returned by {nameof( RestClientJsonTransaction )}.{nameof( RestClientJsonTransaction.Deserialize )} cannot be cast to expected return type of {( typeof( TResult ).Name )}" )
                : _result;
    }

    private static async Task<TResult> GetResult<TResult>( HttpResponseMessage response )
        where TResult : class,new()
    {
        var result = JsonConvert.DeserializeObject<TResult>( await response.Content.ReadAsStringAsync() );
        return result is not TResult _result 
            ? throw new JsonSerializationException( $"Could not deserialize http response content to type of {typeof(TResult).Name}" )
            : _result;
    }
}
