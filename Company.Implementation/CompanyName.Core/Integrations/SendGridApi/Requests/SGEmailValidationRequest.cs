namespace CompanyName.Core.Integrations.SendGridApi;

public record SGEmailValidationRequest
{
    public string Email { get; init; } = String.Empty;
    public string? Source { get; init; }

}
