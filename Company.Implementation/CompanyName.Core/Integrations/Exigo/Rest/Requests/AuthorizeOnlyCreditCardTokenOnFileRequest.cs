// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AuthorizeOnlyCreditCardTokenOnFileRequest : BaseAuthorizeOnlyCreditCardTokenRequest
{
    public AccountCreditCardType CreditCardAccountType { get; init; }
    public int WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public int CustomerID { get; init; }
    public Decimal Amount { get; init; }
    public string CustomerKey { get; init; }

    public AuthorizeOnlyCreditCardTokenOnFileRequest() : base()
    {
        CurrencyCode = String.Empty;
        CustomerKey = String.Empty;
    }
}
