// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerBillingResponse : ApiResponse
{
    public CreditCardAccountResponse? PrimaryCreditCard { get; init; }
    public CreditCardAccountResponse? SecondaryCreditCard { get; init; }
    public BankAccountResponse? BankAccount { get; init; }
    public WalletAccountResponse? PrimaryWalletAccount { get; init; }
    public WalletAccountResponse? SecondaryWallletAccount { get; init; }
    public WalletAccountResponse? ThirdWalletAccount { get; init; }
    public WalletAccountResponse? FourthWalletAccount { get; init; }
    public WalletAccountResponse? FifthWalletAccount { get; init; }

    public GetCustomerBillingResponse() : base()
    {
    }
}
