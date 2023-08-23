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
namespace CompanyName.Core.Entities.Order;

public record CreditCardAccount 
{
    public string CvcCode { get; init; }
    public string CreditCardToken { get ; init ; } 
    public int? CreditCardTypeId { get; init; }
    public int? ExpirationMonth { get; init; }
    public int? ExpirationYear { get; init; }
    public string LastFourDigits { get; init; }
    public string DisplayValue { get; init; }
    public string BillingName { get; init; } 
    public Address BillingAddress { get; init; }

    public CreditCardAccount()
    {
        CvcCode = String.Empty;
        CreditCardToken = String.Empty;
        LastFourDigits= String.Empty;
        DisplayValue = String.Empty;
        BillingName = String.Empty;
        BillingAddress = new Address();
    }
    public bool IsDefault => Equals( None );
    public static readonly CreditCardAccount None = new();

}

