// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record RefundPriorDebitChargeRequest : BaseDebitBankAccountRequest, ITransactionMember
{
    public int ReturnPaymentID { get; init; }
    public int OrderID { get; init; }
    public bool RefundOriginalOrder { get; init; }
    public Decimal? MaxAmount { get; init; }
    public string OrderKey { get; init; }

    public RefundPriorDebitChargeRequest( ) : base ( ) => OrderKey = String.Empty;
}
