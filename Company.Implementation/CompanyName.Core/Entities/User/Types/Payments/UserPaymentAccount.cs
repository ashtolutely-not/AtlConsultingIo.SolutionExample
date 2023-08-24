namespace CompanyName.Core.Entities.User;

public record UserPaymentAccount<T> where T : class,new()
{
    public PaymentProfileType ProfileType { get; protected init; }
    public string AccountId { get; protected init; } = String.Empty;
    public T AccountData { get; protected init; } = new();

    public UserPaymentAccount()
    {

    }

    protected UserPaymentAccount( PaymentProfileType profileType, string accountId , T accountData )
    {
        ProfileType = profileType;
        AccountId = accountId;
        AccountData = accountData;
    }

    public static explicit operator UserPaymentAccount<T>?( UserPaymentAccount account )
        => account.AccountData is T ? 
            new UserPaymentAccount<T>( account.ProfileType, account.AccountId, (T) account.AccountData ) : 
            null;

    public static implicit operator UserPaymentAccount( UserPaymentAccount<T> account )
        => new( account.ProfileType, account.AccountId, account.AccountData ?? new object() );
}

public record UserPaymentAccount
{
    public PaymentProfileType ProfileType { get; private init; }
    public string AccountId { get; private init; } = String.Empty;
    public object AccountData { get; private init; } = new();

    public UserPaymentAccount( PaymentProfileType profileType, string accountId , object accountData )
    {
        ProfileType = profileType;
        AccountId = accountId;
        AccountData = accountData;
    }
}
