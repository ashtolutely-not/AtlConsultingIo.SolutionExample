namespace AtlConsultingIo.IntegrationOperations;

public record RestClientJsonCommand : IntegrationRequest<RestClientJsonCommand>
{
    public RestClientJsonCommand()
    {
    }

    public RestClientJsonCommand( IntegrationRequest<RestClientJsonCommand> original ) : base( original )
    {
    }

    public HttpMethod HttpMethod { get; init; } = HttpMethod.Post;
    public ApiEndpoint SendUrl { get; init; }
    public object JsonData { get; init; } = null!;
    public Func<object,ValueTask<string>>? Serialize { get; init; } 


}
