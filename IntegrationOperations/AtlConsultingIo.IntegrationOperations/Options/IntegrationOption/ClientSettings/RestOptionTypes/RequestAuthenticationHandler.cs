
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;




namespace AtlConsultingIo.IntegrationOperations;
internal class RequestAuthenticationHandler : DelegatingHandler
{
    private readonly HttpClient _defaultClient;
    private readonly IAppCache _tokenCache;
    private readonly IOptionsMonitor<RestClientConfiguration> _options;

    public RequestAuthenticationHandler( HttpClient httpClient , IAppCache appCache , IOptionsMonitor<RestClientConfiguration> clientOptions )
    {
        _defaultClient = httpClient;
        _tokenCache = appCache;
        _options = clientOptions;
    }
    protected override async Task<HttpResponseMessage> SendAsync( HttpRequestMessage request , CancellationToken cancellationToken )
    {
        IntegrationKey? clientName = request.GetIntegrationNameOption();

        if ( !clientName.HasValue )
            return await base.SendAsync( request , cancellationToken ); 

        var _name = clientName.Value;
        var configuration = _options.Get( _name );

        if( HasBasicAuthConfiguration( configuration ))
            request = SetBasicAuthHeader( request, configuration.ApiUser! );

        if( HasApiKeyConfiguration( configuration ))
            request = SetApiKey( request, configuration.ApiKey! );

        if( HasOAuthConfiguration( configuration ))
            request = await SetOAuthToken( request, _name , configuration.OAuthCredentials!, cancellationToken );

        return await base.SendAsync( request, cancellationToken );
    }


    async Task<HttpRequestMessage> SetOAuthToken( HttpRequestMessage request, IntegrationKey integrationName, OAuthTokenOptions configuration, CancellationToken cancellationToken )
    {
        string? token = await GetOAuthToken( integrationName ,configuration, cancellationToken );
        if( token.HasValue() )
            request.Headers.Authorization = new AuthenticationHeaderValue( "Bearer", token! );
        return request;
    }
    async ValueTask<string?> GetOAuthToken(IntegrationKey integrationName, OAuthTokenOptions configuration , CancellationToken cancellationToken )
    {
        if( !configuration.TokenEndpoint.IsEmpty )
            return null;

        string cacheKey = $"{(string)integrationName.SafeName}_OAuthToken";
        string cacheResult = _tokenCache.Get<string>( cacheKey );

        if( cacheResult.HasValue() )
            return cacheResult;

        return await GetNewOAuthToken( configuration, cancellationToken );
    }
    async Task<string?> GetNewOAuthToken( OAuthTokenOptions options , CancellationToken cancellationToken )
    {
        var tokenReq = new HttpRequestMessage
        {
            RequestUri = new(options.TokenEndpoint),
            Method = HttpMethod.Post,
            Content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new("grant_type", "client_credentials"),
                    new("client_id", options.ClientId),
                    new("client_secret", options.ClientSecret)
                })
        };

        HttpResponseMessage tokenRes = await _defaultClient.SendAsync(tokenReq, cancellationToken);
        if( !tokenRes.IsSuccessStatusCode ) 
            return null;

        JObject json = JObject.Parse( await tokenRes.Content.ReadAsStringAsync( cancellationToken ) );
        return json.Value<string?>("access_token");
    }
    static HttpRequestMessage SetBasicAuthHeader( HttpRequestMessage request , ApiUserOptions options )
    {
        string headerValue =  Convert.ToBase64String( Encoding.UTF8.GetBytes( $"{options.Username}:{options.Password}" ) );
        request.Headers.Authorization = new AuthenticationHeaderValue( "Basic" , headerValue );

        return request;
    }
    static HttpRequestMessage SetApiKey( HttpRequestMessage request , ApiKeyOptions options )
    {
        if( options.UseQueryParam && options.QueryParamName.HasValue() )
        {
            Url updated = request.RequestUri.SetQueryParam( options.QueryParamName!, options.ApiKey );
            request.RequestUri = updated.ToUri();
            return request;
        }

        if( options.UseAuthenticationHeader )
        {
            request.Headers.Authorization = new AuthenticationHeaderValue( options.AuthenticationScheme , options.ApiKey );
            return request;
        }

        if( options.CustomHeaderName.HasValue() )
        {
            bool added = request.Headers.TryAddWithoutValidation( options.CustomHeaderName!, options.ApiKey );
            if(!added)
                throw new InvalidOperationException( $"Could not add the custom authentication header with name of {options.CustomHeaderName} to the request header collection." );
            return request;
        }

        return request;
    }



    static bool HasBasicAuthConfiguration( RestClientConfiguration configuration )
        => configuration.ApiUser is ApiUserOptions _user && _user.Username.HasValue() && _user.Password.HasValue();

    static bool HasApiKeyConfiguration ( RestClientConfiguration configuration )
        => configuration.ApiKey is ApiKeyOptions _key && _key.ApiKey.HasValue() && ( _key.CustomHeaderName ?? _key.QueryParamName ?? _key.AuthenticationScheme ).HasValue();

    static bool HasOAuthConfiguration( RestClientConfiguration configuration )
        => configuration.OAuthCredentials is OAuthTokenOptions _oauth && _oauth.ClientId.HasValue() && _oauth.ClientSecret.HasValue() && !_oauth.TokenEndpoint.IsEmpty;
}
