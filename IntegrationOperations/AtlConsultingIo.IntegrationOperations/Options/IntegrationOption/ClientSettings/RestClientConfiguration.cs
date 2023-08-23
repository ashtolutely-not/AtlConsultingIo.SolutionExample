
namespace AtlConsultingIo.IntegrationOperations;

public sealed record RestClientConfiguration
{

    public ApiEndpoint BaseUrl { get; set; } 
    public string? UserAgent { get; set; }


    /// <summary>
    /// When set to true, if TryAddHeaders returns false, an InvalidOperationException will be thrown.
    /// </summary>
    public bool CustomHeadersRequired { get; set; }

    public OAuthTokenOptions? OAuthCredentials { get; set; }
    public ApiUserOptions? ApiUser { get; set; }
    public ApiKeyOptions? ApiKey { get; set; }
    public Dictionary<string , string>? CustomHeaders { get; set; }

    public static readonly RestClientConfiguration Default = new();

}
