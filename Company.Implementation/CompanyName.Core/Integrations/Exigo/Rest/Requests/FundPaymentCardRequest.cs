// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record FundPaymentCardRequest : BaseCreatePayoutRequest
{
    public int PaymentCardTypeID { get; init; }
    public int[] BillIDList { get; init; }

    public FundPaymentCardRequest( ) : base ( ) => BillIDList = new int[ 0 ];
}
