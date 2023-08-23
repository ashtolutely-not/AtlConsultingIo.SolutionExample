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
public record ValidateCreditCardTokenRequest : ApiRequest
{
    public string CreditCardIdentifier { get; init; }
    public int? ExpirationYear { get; init; }
    public int? ExpirationMonth { get; init; }
    public string CvcCode { get; init; }
    public string BillingName { get; init; }
    public string BillingAddress1 { get; init; }
    public string BillingAddress2 { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public int? CustomerID { get; init; }
    public string CustomerKey { get; init; }
    public int? OrderID { get; init; }
    public string OrderKey { get; init; }
    public string Other1 { get; init; }
    public string Other2 { get; init; }
    public string Other3 { get; init; }
    public string Other4 { get; init; }
    public string Other5 { get; init; }
    public string Other6 { get; init; }
    public string Other7 { get; init; }
    public string Other8 { get; init; }
    public string Other9 { get; init; }
    public string Other10 { get; init; }
    public bool ValidateTokenOnFile { get; init; }
    public TokenAccount AccountOnFile { get; init; }
    public int WarehouseID { get; init; }
    public string CurrencyCode { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string ClientIpAddress { get; init; }

    public ValidateCreditCardTokenRequest() : base()
    {
        CreditCardIdentifier = String.Empty;
        CvcCode = String.Empty;
        BillingName = String.Empty;
        BillingAddress1 = String.Empty;
        BillingAddress2 = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        CustomerKey = String.Empty;
        OrderKey = String.Empty;
        Other1 = String.Empty;
        Other2 = String.Empty;
        Other3 = String.Empty;
        Other4 = String.Empty;
        Other5 = String.Empty;
        Other6 = String.Empty;
        Other7 = String.Empty;
        Other8 = String.Empty;
        Other9 = String.Empty;
        Other10 = String.Empty;
        CurrencyCode = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        ClientIpAddress = String.Empty;
    }
}
