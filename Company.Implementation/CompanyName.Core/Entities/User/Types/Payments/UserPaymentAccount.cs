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
