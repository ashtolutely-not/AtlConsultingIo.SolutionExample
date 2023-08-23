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

public record UserWalletAccount : UserPaymentAccount<WalletAccount>
{
    [JsonConstructor]
    private UserWalletAccount() { }
    public UserWalletAccount( PaymentProfileType profileType, WalletAccount account )
    {
        ProfileType = profileType;
        AccountData = account;
    }

    public UserWalletAccount( UserPaymentAccount<WalletAccount>  paymentAccount )
    {
        ProfileType = paymentAccount.ProfileType;
        AccountData = paymentAccount.AccountData;
    }

}

