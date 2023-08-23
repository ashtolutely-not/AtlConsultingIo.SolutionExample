using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
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
