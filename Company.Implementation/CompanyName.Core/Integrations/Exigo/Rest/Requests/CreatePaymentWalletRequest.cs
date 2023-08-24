// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePaymentWalletRequest : BaseCreatePaymentRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public int WalletType { get; init; }
    public string WalletAccount { get; init; }
    public string AuthorizationCode { get; init; }
    public string Memo { get; init; }
    public string BillingName { get; init; }
    public string OrderKey { get; init; }

    public CreatePaymentWalletRequest() : base()
    {
        WalletAccount = String.Empty;
        AuthorizationCode = String.Empty;
        Memo = String.Empty;
        BillingName = String.Empty;
        OrderKey = String.Empty;
    }
}
