// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreatePayoutRequest : BaseCreatePayoutRequest
{
    public int[] BillIDs_ToPay { get; init; }
    public int VendorPaymentTypeID { get; init; }

    public CreatePayoutRequest( ) : base ( ) => BillIDs_ToPay = new int[ 0 ];
}
