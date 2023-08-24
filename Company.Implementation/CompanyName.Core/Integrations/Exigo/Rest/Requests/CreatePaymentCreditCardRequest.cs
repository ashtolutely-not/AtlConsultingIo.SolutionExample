// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePaymentCreditCardRequest :
    BaseCreatePaymentCreditCardRequest,
    ITransactionMember
{
    public int OrderID { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public string CreditCardNumber { get; init; }
    public int ExpirationMonth { get; init; }
    public int ExpirationYear { get; init; }
    public string BillingName { get; init; }
    public string BillingAddress { get; init; }
    public string BillingAddress2 { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public int? CreditCardType { get; init; }
    public string AuthorizationCode { get; init; }
    public string Memo { get; init; }
    public string OrderKey { get; init; }
    public string MerchantTransactionKey { get; init; }

    public CreatePaymentCreditCardRequest() : base()
    {
        CreditCardNumber = String.Empty;
        BillingName = String.Empty;
        BillingAddress = String.Empty;
        BillingAddress2 = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        AuthorizationCode = String.Empty;
        Memo = String.Empty;
        OrderKey = String.Empty;
        MerchantTransactionKey = String.Empty;
    }
}
