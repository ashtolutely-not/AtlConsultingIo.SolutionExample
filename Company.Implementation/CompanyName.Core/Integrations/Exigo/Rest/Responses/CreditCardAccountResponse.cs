// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreditCardAccountResponse
{
    public string CreditCardNumberDisplay { get; init; }
    public string CreditCardToken { get; init; }
    public int ExpirationMonth { get; init; }
    public int ExpirationYear { get; init; }
    public int CreditCardType { get; init; }
    public string CreditCardTypeDescription { get; init; }
    public string BillingName { get; init; }
    public string BillingAddress { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public string BillingAddress2 { get; init; }

    public CreditCardAccountResponse() : base()
    {
        CreditCardNumberDisplay = String.Empty;
        CreditCardToken = String.Empty;
        CreditCardTypeDescription = String.Empty;
        BillingName = String.Empty;
        BillingAddress = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        BillingAddress2 = String.Empty;
    }
}
