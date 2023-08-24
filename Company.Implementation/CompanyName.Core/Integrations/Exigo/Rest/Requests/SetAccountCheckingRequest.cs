// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetAccountCheckingRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public string BankAccountNumber { get; init; }
    public string BankRoutingNumber { get; init; }
    public string BankName { get; init; }
    public BankAccountType BankAccountType { get; init; }
    public string NameOnAccount { get; init; }
    public bool UseMainAddress { get; init; }
    public string BillingAddress { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public string DriversLicenseNumber { get; init; }
    public string Iban { get; init; }
    public string SwiftCode { get; init; }
    public string CustomerKey { get; init; }

    public SetAccountCheckingRequest() : base()
    {
        BankAccountNumber = String.Empty;
        BankRoutingNumber = String.Empty;
        BankName = String.Empty;
        NameOnAccount = String.Empty;
        BillingAddress = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        DriversLicenseNumber = String.Empty;
        Iban = String.Empty;
        SwiftCode = String.Empty;
        CustomerKey = String.Empty;
    }
}
