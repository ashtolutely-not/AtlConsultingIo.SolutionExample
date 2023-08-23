namespace AtlConsultingIo.IntegrationOperations;

public record RestClientJsonQuery : IntegrationRequest<RestClientJsonQuery>
{
    public RestClientJsonQuery()
    {
    }

    public RestClientJsonQuery( IntegrationRequest<RestClientJsonQuery> original ) : base( original )
    {
    }

    public ApiEndpoint SendUrl { get; init; }
    public Dictionary<string,object>? QueryParams { get; init; }
    public Func<HttpResponseMessage,Task<object>>? Deserialize { get; init; }


}

