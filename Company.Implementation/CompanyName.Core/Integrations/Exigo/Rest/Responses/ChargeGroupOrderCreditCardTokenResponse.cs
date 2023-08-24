// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChargeGroupOrderCreditCardTokenResponse : ApiResponse
{
    public PaymentsResponse[] _paymentIDs { get; init; }
    public Decimal Amount { get; init; }
    public string AuthorizationCode { get; init; }
    public PaymentsResponse[] Payments { get; init; }

    public ChargeGroupOrderCreditCardTokenResponse() : base()
    {
        _paymentIDs = new PaymentsResponse[0];
        AuthorizationCode = String.Empty;
        Payments = new PaymentsResponse[0];
    }
}
