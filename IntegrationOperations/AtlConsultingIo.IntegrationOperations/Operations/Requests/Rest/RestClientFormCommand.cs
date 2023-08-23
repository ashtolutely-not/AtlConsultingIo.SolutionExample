
namespace AtlConsultingIo.IntegrationOperations;
public record RestClientFormCommand : IntegrationRequest<RestClientFormCommand>
{
    public RestClientFormCommand()
    {
    }

    public RestClientFormCommand( IntegrationRequest<RestClientFormCommand> original ) : base( original )
    {
    }

    public HttpMethod HttpMethod { get; init; } = HttpMethod.Post;
    public ApiEndpoint SendUrl { get; init; }
    public IFormContent FormContent { get; init; } = null!;
    

}



