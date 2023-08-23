
using FluentValidation;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public class JsonQueryOperation : IIntegrationQuery<RestClientJsonQuery>
{
    private readonly HttpSendHandler _factory;
    private readonly IValidator<RestClientJsonQuery> _validator;
    public JsonQueryOperation( HttpSendHandler resultFactory , IValidator<RestClientJsonQuery> validator )
    {
        _factory = resultFactory;
        _validator = validator;
    }

    public async Task<QuerySuccess<TResult>> Execute<TResult>(
        RestClientJsonQuery request ,
        IntegratedClientSettings clientConfiguration ,
        ILogger logger ,
        CancellationToken cancellationToken ) where TResult : class, new()
    {
        logger.OperationStartTrace(
                request.Key ,
                request.ContextID ,
                typeof( JsonQueryOperation )
            );

        _validator.ValidateAndThrow( request );
        Url url = request.QueryParams.HasItems() ?
                        new Url( request.SendUrl).SetQueryParams( request.QueryParams ) :
                        new Url( request.SendUrl );

        HttpRequestMessage httpRequest = new ()
        {
            Method = HttpMethod.Get,
            RequestUri =  new Uri( url, UriKind.Relative )
        };

        HttpSendState state = new (request.Key, request.ContextID, httpRequest);
        state = await _factory.SendAsync( state , cancellationToken );
        if ( state.HttpResponse is not HttpResponseMessage _httpResponse || !_httpResponse.Has2xxStatus() || state.SendException is not null )
            throw new HttpSendException( state );

        var result = request.Deserialize is not null 
                    ? await GetResult<TResult>( state.HttpResponse!, request.Deserialize )
                    : await GetResult<TResult>( state.HttpResponse! );

        logger.OperationEndTrace(
                request.Key ,
                request.ContextID ,
                typeof( JsonQueryOperation )
            );

        return result;
    }

    private static async Task<QuerySuccess<TResult>> GetResult<TResult>( HttpResponseMessage response , Func<HttpResponseMessage , Task<object>> deserialize )
        where TResult : class, new()
    {
        var anon = await deserialize(response);

        var listResult = anon as List<TResult>;
        if( listResult is not null )
            return listResult;

        var typedResult = anon as TResult;
        if( typedResult is not null )
            return typedResult;

        if( typedResult is NotFoundResult _notfound)
            return _notfound;

        throw new InvalidCastException( ErrorMessage<TResult>() );
    }
    private static async Task<TResult> GetResult<TResult>( HttpResponseMessage response )
        where TResult : class, new()
    {
        var result = JsonConvert.DeserializeObject<TResult>( await response.Content.ReadAsStringAsync() );
        return result is not TResult _result
            ? throw new JsonSerializationException( $"Could not deserialize http response content to type of {typeof( TResult ).Name}" )
            : _result;
    }

    static string ErrorMessage<TResult>() 
        => $"Value returned by {nameof( RestClientJsonTransaction )}.{nameof( RestClientJsonTransaction.Deserialize )} cannot be cast to expected return type of {( typeof( TResult ).Name )}.";
}
