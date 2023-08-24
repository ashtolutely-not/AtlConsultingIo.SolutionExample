// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record BaseCreatePaymentResponse : ApiResponse
{
    public string Message { get; init; }
    public string DisplayMessage { get; init; }

    public BaseCreatePaymentResponse() : base()
    {
        Message = String.Empty;
        DisplayMessage = String.Empty;
    }
}
