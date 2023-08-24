using CompanyName.Core.Integrations.Exigo;

namespace CompanyName.Core.Entities.Messaging;
public record ContactEmail : IUserContact
{
    public CustomerID UserID { get; init; }
    public EmailAddress EmailAddress { get; init; } 
    public Enabled IsSubscribed { get; init; }
    public Valid IsValidated { get; init; }
    public string Value => EmailAddress.Value;
}
