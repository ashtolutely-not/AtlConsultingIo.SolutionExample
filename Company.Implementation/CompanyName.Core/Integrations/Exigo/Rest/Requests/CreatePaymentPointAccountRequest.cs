// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePaymentPointAccountRequest : BaseCreatePaymentRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public int PointAccountID { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public string Memo { get; init; }
    public string OrderKey { get; init; }

    public CreatePaymentPointAccountRequest() : base()
    {
        Memo = String.Empty;
        OrderKey = String.Empty;
    }
}
