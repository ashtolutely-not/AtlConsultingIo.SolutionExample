// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChargePriorAuthorizationRequest : BaseCreatePaymentRequest, ITransactionMember
{
    public string MerchantTransactionKey { get; init; }
    public int OrderID { get; init; }
    public Decimal? MaxAmount { get; init; }
    public string OrderKey { get; init; }

    public ChargePriorAuthorizationRequest() : base()
    {
        MerchantTransactionKey = String.Empty;
        OrderKey = String.Empty;
    }
}
