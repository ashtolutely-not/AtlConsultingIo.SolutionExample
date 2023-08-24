using CompanyName.Core.Entities;
using CompanyName.Core.Entities.User;

namespace CompanyName.Operations.Account;
public record GuestAccountSearchParams
{
    public PhoneNumber PhoneNumber { get; init; } = PhoneNumber.Default;
    public EmailAddress EmailAddress { get; init; }
    public WebAlias CheckoutSiteAlias { get; init; }

}
