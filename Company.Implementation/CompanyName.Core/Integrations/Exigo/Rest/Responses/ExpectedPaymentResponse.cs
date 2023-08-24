// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ExpectedPaymentResponse
{
    public int ExpectedPaymentID { get; init; }
    public int CustomerID { get; init; }
    public int PaymentTypeId { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public int? OrderID { get; init; }
    public string CurrencyCode { get; init; }
    public string BillingName { get; init; }
    public string AuthorizationCode { get; init; }
    public string OrderKey { get; init; }
    public string CustomerKey { get; init; }

    public ExpectedPaymentResponse() : base()
    {
        CurrencyCode = String.Empty;
        BillingName = String.Empty;
        AuthorizationCode = String.Empty;
        OrderKey = String.Empty;
        CustomerKey = String.Empty;
    }
}
