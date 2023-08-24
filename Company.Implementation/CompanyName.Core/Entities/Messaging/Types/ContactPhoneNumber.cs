using CompanyName.Core.Integrations.Exigo;

namespace CompanyName.Core.Entities.Messaging;

public record ContactPhoneNumber : IUserContact
{
    public CustomerID UserID { get; init; }
    public PhoneNumber PhoneNumber { get; init; } = PhoneNumber.Default;
    public Enabled IsSubscribed { get; init; }

    public string Value => PhoneNumber.CleanValue.Value;
}
