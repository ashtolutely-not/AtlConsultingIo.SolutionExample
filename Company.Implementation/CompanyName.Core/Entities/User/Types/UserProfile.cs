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
namespace CompanyName.Core.Entities.User;
public record ECommAppUser
{
    //API Models
    public CustomerID AccountId => Account.AccountId;

    public AccountResult Account { get; private init; } = AccountResult.Default;
    public UserSite? Site { get; init; } = UserSite.Default;
    public EnrollerAccount? Enroller { get; init; }

    public List<UserWalletAccount> WalletAccounts { get; init; } = new ();    
    public List<UserCreditCardAccount> CreditCardAccounts { get; init; } = new ();
    public List<UserPointAccount> PointAccounts { get; init; } = new ();

    public string[] CustomerGroups { get; init; } = new string[ 0 ];

    //OUT OF SCOPE V1 -- We need to build out stronger validations and data to respect settings for compliance requirements
    public List<ContactEmail> EmailContacts { get;  init; } = new();
    public List<ContactPhoneNumber> PhoneContacts { get; init; } = new();

    public ECommAppUser( AccountResult userAccount )
        => Account = userAccount;

}


