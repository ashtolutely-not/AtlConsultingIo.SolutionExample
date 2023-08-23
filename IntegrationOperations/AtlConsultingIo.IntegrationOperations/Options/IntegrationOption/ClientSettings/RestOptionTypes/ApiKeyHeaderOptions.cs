namespace AtlConsultingIo.IntegrationOperations;

public record ApiKeyOptions
{
    public bool UseAuthenticationHeader { get; init; } = true;
    public bool UseQueryParam { get; init; } 
    public string? CustomHeaderName { get; init; }
    public string? QueryParamName { get; init; }
    public string ApiKey { get; init; } = String.Empty;
    public string AuthenticationScheme { get; init; } = String.Empty;
}
