// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record RefundPriorWalletChargeResponse : CreatePaymentResponse
{
    public Decimal Amount { get; init; }
    public string AuthorizationCode { get; init; }

    public RefundPriorWalletChargeResponse( ) : base ( ) => AuthorizationCode = String.Empty;
}
