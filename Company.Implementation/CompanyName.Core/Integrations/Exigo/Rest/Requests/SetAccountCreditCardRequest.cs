// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetAccountCreditCardRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public AccountCreditCardType CreditCardAccountType { get; init; }
    public string CreditCardNumber { get; init; }
    public int ExpirationMonth { get; init; }
    public int ExpirationYear { get; init; }
    public string CvcCode { get; init; }
    public string IssueCode { get; init; }
    public int? CreditCardType { get; init; }
    public string BillingName { get; init; }
    public bool UseMainAddress { get; init; }
    public string BillingAddress { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public bool? HideFromWeb { get; init; }
    public string CustomerKey { get; init; }

    public SetAccountCreditCardRequest() : base()
    {
        CreditCardNumber = String.Empty;
        CvcCode = String.Empty;
        IssueCode = String.Empty;
        BillingName = String.Empty;
        BillingAddress = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        CustomerKey = String.Empty;
    }
}
