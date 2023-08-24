namespace CompanyName.Core.Integrations.SendGridApi;

public record SGValidationResults
{
    [JsonProperty( "domain" )] 
    public SGDomainValidationResult DomainResult { get; init; } = new();
    [JsonProperty( "local_part" )]
    public SGLocalValidationResult LocalResult { get; init; }   = new();
    [JsonProperty( "additional" )]
    public SGBounceRateValidationResult BounceResult { get; init; } = new();
}

public record SGDomainValidationResult
{
    [JsonProperty( "has_valid_address_syntax" )]
    public bool HasValidSyntax { get; init; }

    [JsonProperty( "has_mx_or_a_record" )]
    public bool HasMXRecord { get; init; }

    [JsonProperty( "is_suspected_disposable_address" )]
    public bool IsDisposable { get; init; }
}

public record SGLocalValidationResult
{
    [JsonProperty( "is_suspected_role_address" )]
    public bool IsGroupAddress { get; init; }
}

public record SGBounceRateValidationResult
{
    [JsonProperty( "has_known_bounces" )]
    public bool HasKnownBounces { get; init; }

    [JsonProperty( "has_suspected_bounces" )]
    public bool HasSuspectedBounces { get; init; }
}
