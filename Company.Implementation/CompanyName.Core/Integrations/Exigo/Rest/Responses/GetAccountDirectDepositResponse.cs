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
public record GetAccountDirectDepositResponse : ApiResponse
{
    public string NameOnAccount { get; init; }
    public string BankAccountNumberDisplay { get; init; }
    public string BankRoutingNumber { get; init; }
    public string DepositAccountType { get; init; }
    public string BankName { get; init; }
    public string BankAddress { get; init; }
    public string BankCity { get; init; }
    public string BankState { get; init; }
    public string BankZip { get; init; }
    public string BankCountry { get; init; }
    public BankAccountType BankAccountType { get; init; }
    public string Iban { get; init; }
    public string SwiftCode { get; init; }
    public int? DepositAccountTypeID { get; init; }

    public GetAccountDirectDepositResponse() : base()
    {
        NameOnAccount = String.Empty;
        BankAccountNumberDisplay = String.Empty;
        BankRoutingNumber = String.Empty;
        DepositAccountType = String.Empty;
        BankName = String.Empty;
        BankAddress = String.Empty;
        BankCity = String.Empty;
        BankState = String.Empty;
        BankZip = String.Empty;
        BankCountry = String.Empty;
        Iban = String.Empty;
        SwiftCode = String.Empty;
    }
}
