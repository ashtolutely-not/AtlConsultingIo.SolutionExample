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
