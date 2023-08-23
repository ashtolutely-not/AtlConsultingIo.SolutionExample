

namespace AtlConsultingIo.IntegrationOperations;

public record RestClientFormTransaction : IntegrationRequest<RestClientFormTransaction>
{
    public HttpMethod HttpMethod { get; init; } = HttpMethod.Post;
    public ApiEndpoint SendUrl { get; init; }
    public IFormContent FormContent { get; init; } = null!;
    public Func<HttpResponseMessage,Task<object>> Convert { get; init; } = null!;

    public RestClientFormTransaction()
    {
        
    }

    public RestClientFormTransaction( IntegrationRequest<RestClientFormTransaction> original ) : base( original )
    {
    }
}



