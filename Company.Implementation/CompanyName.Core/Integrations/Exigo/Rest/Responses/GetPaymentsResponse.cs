// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetPaymentsResponse : ApiResponse
{
    public PaymentResponse[] Payments { get; init; }

    public GetPaymentsResponse( ) : base ( ) => Payments = new PaymentResponse[ 0 ];
}
