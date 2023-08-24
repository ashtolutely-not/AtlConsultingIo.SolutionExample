// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AuthorizeOnlyCreditCardResponse : ApiResponse
{
    public string AuthorizationCode { get; init; }
    public string MerchantTransactionKey { get; init; }
    public string Message { get; init; }
    public string DisplayMessage { get; init; }

    public AuthorizeOnlyCreditCardResponse() : base()
    {
        AuthorizationCode = String.Empty;
        MerchantTransactionKey = String.Empty;
        Message = String.Empty;
        DisplayMessage = String.Empty;
    }
}
