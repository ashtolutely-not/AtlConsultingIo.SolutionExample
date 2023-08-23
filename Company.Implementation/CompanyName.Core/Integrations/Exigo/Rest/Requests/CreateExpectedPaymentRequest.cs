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
public record CreateExpectedPaymentRequest : BaseCreateExpectedPaymentRequest, ITransactionMember
{
    public int OrderID { get; init; }
    public DateTime PaymentDate { get; init; }
    public Decimal Amount { get; init; }
    public PaymentType PaymentType { get; init; }
    public string AuthorizationCode { get; init; }
    public string OrderKey { get; init; }

    public CreateExpectedPaymentRequest() : base()
    {
        AuthorizationCode = String.Empty;
        OrderKey = String.Empty;
    }
}
