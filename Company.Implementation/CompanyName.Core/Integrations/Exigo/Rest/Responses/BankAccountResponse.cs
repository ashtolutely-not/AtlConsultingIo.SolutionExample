// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record BankAccountResponse
{
    public string BankAccountNumberDisplay { get; init; }
    public string BankRoutingNumber { get; init; }
    public string BankName { get; init; }
    public BankAccountType BankAccountType { get; init; }
    public string NameOnAccount { get; init; }
    public string BillingAddress { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public string BillingAddress2 { get; init; }
    public string CheckIban { get; init; }
    public string CheckSwiftCode { get; init; }

    public BankAccountResponse() : base()
    {
        BankAccountNumberDisplay = String.Empty;
        BankRoutingNumber = String.Empty;
        BankName = String.Empty;
        NameOnAccount = String.Empty;
        BillingAddress = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        BillingAddress2 = String.Empty;
        CheckIban = String.Empty;
        CheckSwiftCode = String.Empty;
    }
}
