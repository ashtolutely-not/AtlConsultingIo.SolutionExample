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

