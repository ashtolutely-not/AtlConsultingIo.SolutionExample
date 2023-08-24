// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetAccountWalletRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public AccountWalletType WalletAccountType { get; init; }
    public int WalletType { get; init; }
    public string WalletAccount { get; init; }
    public string WalletOther1 { get; init; }
    public string WalletOther2 { get; init; }
    public string WalletOther3 { get; init; }
    public string CustomerKey { get; init; }

    public SetAccountWalletRequest() : base()
    {
        WalletAccount = String.Empty;
        WalletOther1 = String.Empty;
        WalletOther2 = String.Empty;
        WalletOther3 = String.Empty;
        CustomerKey = String.Empty;
    }
}
