using CompanyName.Core.Entities.Order;
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

