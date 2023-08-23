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
public record ChargeCreditCardTokenRequest : BaseChargeCreditCardRequest, ITransactionMember
{
    public string CreditCardToken { get; init; }
    public string BillingName { get; init; }
    public string BillingAddress { get; init; }
    public string BillingAddress2 { get; init; }
    public string BillingCity { get; init; }
    public string BillingState { get; init; }
    public string BillingZip { get; init; }
    public string BillingCountry { get; init; }
    public string CvcCode { get; init; }
    public string IssueNumber { get; init; }
    public int? CreditCardType { get; init; }
    public int? ExpirationMonth { get; init; }
    public int? ExpirationYear { get; init; }
    public int OrderID { get; init; }
    public Decimal? MaxAmount { get; init; }
    public int? MerchantWarehouseIDOverride { get; init; }
    public string ClientIPAddress { get; init; }
    public string OtherData1 { get; init; }
    public string OtherData2 { get; init; }
    public string OtherData3 { get; init; }
    public string OtherData4 { get; init; }
    public string OtherData5 { get; init; }
    public string OtherData6 { get; init; }
    public string OtherData7 { get; init; }
    public string OtherData8 { get; init; }
    public string OtherData9 { get; init; }
    public string OtherData10 { get; init; }
    public string OrderKey { get; init; }

    public ChargeCreditCardTokenRequest() : base()
    {
        CreditCardToken = String.Empty;
        BillingName = String.Empty;
        BillingAddress = String.Empty;
        BillingAddress2 = String.Empty;
        BillingCity = String.Empty;
        BillingState = String.Empty;
        BillingZip = String.Empty;
        BillingCountry = String.Empty;
        CvcCode = String.Empty;
        IssueNumber = String.Empty;
        ClientIPAddress = String.Empty;
        OtherData1 = String.Empty;
        OtherData2 = String.Empty;
        OtherData3 = String.Empty;
        OtherData4 = String.Empty;
        OtherData5 = String.Empty;
        OtherData6 = String.Empty;
        OtherData7 = String.Empty;
        OtherData8 = String.Empty;
        OtherData9 = String.Empty;
        OtherData10 = String.Empty;
        OrderKey = String.Empty;
    }
}
