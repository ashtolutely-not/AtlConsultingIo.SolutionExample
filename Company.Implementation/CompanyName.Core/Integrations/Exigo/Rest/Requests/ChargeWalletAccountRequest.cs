// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record ChargeWalletAccountRequest : BaseChargeWalletAccountRequest, ITransactionMember
{
    public string WalletAccountNumber { get; init; }
    public int WalletTy { get; init; }
    public int OrderID { get; init; }
    public string Memo { get; init; }
    public Decimal? MaxAmount { get; init; }
    public string OrderKey { get; init; }

    public ChargeWalletAccountRequest() : base()
    {
        WalletAccountNumber = String.Empty;
        Memo = String.Empty;
        OrderKey = String.Empty;
    }
}
