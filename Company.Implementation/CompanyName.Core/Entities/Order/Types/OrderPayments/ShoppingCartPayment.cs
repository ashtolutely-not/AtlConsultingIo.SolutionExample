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
namespace CompanyName.Core.Entities.Order;

public record ShoppingCartPayment
{

    public PaymentAccountChargeAmount ChargeAmount { get; init; }
    public object ChargeAccount { get; init; }

    public ShoppingCartPayment( )
    {
        ChargeAmount = new();
        ChargeAccount = new();
    }

    public ShoppingCartPayment( decimal chargeAmount , object paymentAccount )
    {
        ChargeAmount = IDecimalValue.Create<PaymentAccountChargeAmount> ( chargeAmount );
        ChargeAccount = paymentAccount;
    }
}
