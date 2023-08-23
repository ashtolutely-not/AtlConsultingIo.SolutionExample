using Polly;

using System.Net.Http;

namespace AtlConsultingIo.IntegrationOperations;

public sealed class HttpSendHandler : IHttpSendHandler
{
    private readonly IHttpClientFactory _factory;


    public HttpSendHandler( IHttpClientFactory clientFactory )
    {
        _factory = clientFactory;
    }


    public async Task<HttpSendState> SendAsync( HttpSendState sendState , CancellationToken cancellationToken )
    {
        HttpSendState _state = sendState;
        IntegrationKey _clientName = _state.ClientName;

        try
        {
            _state.HttpRequest.Options.Set( new HttpRequestOptionsKey<IntegrationKey>( nameof( IntegrationKey ) ) , _clientName );

            _ = _state
                    .HttpRequest
                    .Headers
                    .TryAddWithoutValidation(
                            "atlconsultingio-operations-operationcontextid" ,
                            _state.ContextID.Value
                        );

            HttpClient client = _factory.CreateClient( _clientName );
            var response = await client.SendAsync( _state.HttpRequest , cancellationToken );
            _state = _state.WithHttpResponse( response );

        }
        catch ( Exception err )
        {
            _state = _state.WithSendException( err );
        }

        return _state;
    }

}
