
namespace AtlConsultingIo.IntegrationOperations;

public record OAuthTokenOptions
{
    public ApiEndpoint TokenEndpoint { get; set; } 
    public string ClientId { get; init; } = string.Empty;
    public string ClientSecret { get; init; } = string.Empty;
}
