// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateExpectedPaymentRequest : BaseCreateExpectedPaymentRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public PaymentType PaymentType { get; init; }
    public string AuthorizationCode { get; init; }
    public string OrderKey { get; init; }

    public CreateExpectedPaymentRequest() : base()
    {
        AuthorizationCode = String.Empty;
        OrderKey = String.Empty;
    }
}
