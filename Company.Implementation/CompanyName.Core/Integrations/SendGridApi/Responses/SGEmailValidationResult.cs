namespace CompanyName.Core.Integrations.SendGridApi;

public record SGEmailValidationResult
{
    //we want to allow sending to emails where the response is the default, ie no verdict, meaning something went wrong in HTTP communication
    public bool IsValid => !string.IsNullOrWhiteSpace(Verdict) && !Verdict.ToLower().Equals( "invalid" );
    public bool IsDefault => Equals( Default );
    public int Score { get; init; }
    public string Email { get; init; }
    public string Verdict { get; init; }

    [JsonProperty( "local" )]
    public string LocalAddress { get; init; }

    [JsonProperty( "host" )]
    public string EmailDomain { get; init; }

    [JsonProperty( "ip_address" )]
    public string EmailAddressIP { get; init; }

    public string? Suggestion { get; init; }
    public string? Source { get; init; }

    [JsonProperty( "checks" )]
    public SGValidationResults? Results { get; init; }

    public SGEmailValidationResult()
    {
        Email = string.Empty;
        Verdict = string.Empty;
        LocalAddress = string.Empty;
        EmailDomain = string.Empty;
        EmailAddressIP = string.Empty;
    }

    public static readonly SGEmailValidationResult Default = new();
}
