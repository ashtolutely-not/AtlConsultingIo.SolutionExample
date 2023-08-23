namespace AtlConsultingIo.IntegrationOperations;

public record RestClientJsonTransaction : IntegrationRequest<RestClientJsonTransaction>
{
    public RestClientJsonTransaction()
    {
    }

    public RestClientJsonTransaction( IntegrationRequest<RestClientJsonTransaction> original ) : base( original )
    {
    }

    public HttpMethod HttpMethod { get; init; } = HttpMethod.Post;
    public ApiEndpoint SendUrl { get; init; }
    public object JsonData { get; init; } = null!;
    public Func<object , ValueTask<string>>? Serialize { get; init; }
    public Func<HttpResponseMessage,Task<object>>? Deserialize { get; init; } 


}
