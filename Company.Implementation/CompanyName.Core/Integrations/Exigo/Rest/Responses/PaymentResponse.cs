// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record PaymentResponse
{
    public int PaymentID { get; init; }
    public int CustomerID { get; init; }
    public int PaymentTypeId { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public int? OrderID { get; init; }
    public string CurrencyCode { get; init; }
    public string BillingName { get; init; }
    public string BillingAddress1 { get; init; }
    public string BillingAddress2 { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public string BankName { get; init; }
    public string Memo { get; init; }
    public string CreditCardNumberDisplay { get; init; }
    public string AuthorizationCode { get; init; }
    public int CreditCardType { get; init; }
    public string CreditCardTypeDescription { get; init; }
    public string OrderKey { get; init; }
    public string CustomerKey { get; init; }
    public int WalletTy { get; init; }

    public PaymentResponse() : base()
    {
        CurrencyCode = String.Empty;
        BillingName = String.Empty;
        BillingAddress1 = String.Empty;
        BillingAddress2 = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        BankName = String.Empty;
        Memo = String.Empty;
        CreditCardNumberDisplay = String.Empty;
        AuthorizationCode = String.Empty;
        CreditCardTypeDescription = String.Empty;
        OrderKey = String.Empty;
        CustomerKey = String.Empty;
    }
}
