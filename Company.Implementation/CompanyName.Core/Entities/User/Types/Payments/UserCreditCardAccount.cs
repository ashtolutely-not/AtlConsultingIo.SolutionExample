using CompanyName.Core.Entities.Order;
namespace CompanyName.Core.Entities.User;

public record UserCreditCardAccount : UserPaymentAccount<CreditCardAccount>
{
    [JsonConstructor]
    private UserCreditCardAccount() { }

    public UserCreditCardAccount( PaymentProfileType profileType, CreditCardAccount accountData )
    {
        ProfileType = profileType;
        AccountData = accountData;
        AccountId = accountData.CreditCardToken;
    }

    public UserCreditCardAccount ( UserPaymentAccount<CreditCardAccount> paymentAccount )
    {
        ProfileType = paymentAccount.ProfileType;
        AccountData = paymentAccount.AccountData;
    }

}

