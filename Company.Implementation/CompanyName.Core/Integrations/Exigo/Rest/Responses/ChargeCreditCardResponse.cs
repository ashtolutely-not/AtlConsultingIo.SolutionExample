// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChargeCreditCardResponse : CreatePaymentCreditCardResponse
{
    public Decimal Amount { get; init; }
    public string AuthorizationCode { get; init; }

    //Generator doesn't handle properties derived from more than one level of inheritence
    //public string Message { get; init; }
    //public string DisplayMessage { get; init; }

    public ChargeCreditCardResponse() : base()
    {
        AuthorizationCode = String.Empty;
        Message = String.Empty;
        DisplayMessage = String.Empty;
    }
}
