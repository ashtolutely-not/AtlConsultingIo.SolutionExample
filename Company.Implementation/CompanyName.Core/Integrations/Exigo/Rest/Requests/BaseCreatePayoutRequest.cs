// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record BaseCreatePayoutRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int BankAccountID { get; init; }
    public string Reference { get; init; }
    public string TransactionNote { get; init; }
    public DateTime? PaymentDate { get; init; }
    public string CustomerKey { get; init; }

    public BaseCreatePayoutRequest() : base()
    {
        Reference = String.Empty;
        TransactionNote = String.Empty;
        CustomerKey = String.Empty;
    }
}
