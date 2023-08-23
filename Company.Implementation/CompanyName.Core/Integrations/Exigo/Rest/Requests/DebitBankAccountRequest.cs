// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record DebitBankAccountRequest : BaseDebitBankAccountRequest, ITransactionMember
{
    public string BankAccountNumber { get; init; }
    public string BankRoutingNumber { get; init; }
    public string BankName { get; init; }
    public BankAccountType BankAccountType { get; init; }
    public string CheckNumber { get; init; }
    public string NameOnAccount { get; init; }
    public string BillingAddress { get; init; }
    public string BillingAddress2 { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public string Iban { get; init; }
    public string SwiftCode { get; init; }
    public int OrderID { get; init; }
    public Decimal? MaxAmount { get; init; }
    public string OrderKey { get; init; }

    public DebitBankAccountRequest() : base()
    {
        BankAccountNumber = String.Empty;
        BankRoutingNumber = String.Empty;
        BankName = String.Empty;
        CheckNumber = String.Empty;
        NameOnAccount = String.Empty;
        BillingAddress = String.Empty;
        BillingAddress2 = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        Iban = String.Empty;
        SwiftCode = String.Empty;
        OrderKey = String.Empty;
    }
}
