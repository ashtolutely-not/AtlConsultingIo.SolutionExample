namespace CompanyName.Operations.Checkout;
public interface ICheckoutService
{
    Task<CheckoutState> CompleteCheckout( CheckoutRequest request , CancellationToken cancellationToken );
}


