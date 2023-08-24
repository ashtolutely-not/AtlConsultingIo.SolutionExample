// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AuthorizeOnlyCreditCardTokenRequest : BaseAuthorizeOnlyCreditCardTokenRequest
{
    public string CreditCardToken { get; init; }
    public Decimal Amount { get; init; }
    public string BillingName { get; init; }
    public string BillingAddress { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public int WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public int CustomerID { get; init; }
    public string CvcCode { get; init; }
    public string CustomerKey { get; init; }

    public AuthorizeOnlyCreditCardTokenRequest() : base()
    {
        CreditCardToken = String.Empty;
        BillingName = String.Empty;
        BillingAddress = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        CurrencyCode = String.Empty;
        CvcCode = String.Empty;
        CustomerKey = String.Empty;
    }
}
