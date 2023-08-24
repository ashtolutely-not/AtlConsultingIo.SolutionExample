// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePaymentCheckRequest : BaseCreatePaymentRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public string Memo { get; init; }
    public string CheckNumber { get; init; }
    public string CheckAccountNumber { get; init; }
    public string CheckRoutingNumber { get; init; }
    public DateTime? CheckDate { get; init; }
    public string OrderKey { get; init; }

    public CreatePaymentCheckRequest() : base()
    {
        Memo = String.Empty;
        CheckNumber = String.Empty;
        CheckAccountNumber = String.Empty;
        CheckRoutingNumber = String.Empty;
        OrderKey = String.Empty;
    }
}
