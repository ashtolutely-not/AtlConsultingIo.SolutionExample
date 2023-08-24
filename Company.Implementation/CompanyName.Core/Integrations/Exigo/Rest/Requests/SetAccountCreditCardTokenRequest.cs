// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetAccountCreditCardTokenRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public AccountCreditCardType CreditCardAccountType { get; init; }
    public string CreditCardToken { get; init; }
    public int ExpirationMonth { get; init; }
    public int ExpirationYear { get; init; }
    public int? CreditCardType { get; init; }
    public string BillingName { get; init; }
    public bool UseMainAddress { get; init; }
    public string BillingAddress { get; init; }
    public string BillingAddress2 { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public bool? HideFromWeb { get; init; }
    public string CustomerKey { get; init; }
    public bool MovePrimaryToSecondary { get; init; }
    public int? TokenType { get; init; }
    public string FirstSix { get; init; }
    public string LastFour { get; init; }

    public SetAccountCreditCardTokenRequest() : base()
    {
        CreditCardToken = String.Empty;
        BillingName = String.Empty;
        BillingAddress = String.Empty;
        BillingAddress2 = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        CustomerKey = String.Empty;
        FirstSix = String.Empty;
        LastFour = String.Empty;
    }
}
