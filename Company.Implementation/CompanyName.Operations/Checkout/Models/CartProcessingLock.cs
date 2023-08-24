using CompanyName.Core.Entities;

namespace CompanyName.Operations.Checkout;
public record CartProcessingLock
{
    public CartID Id { get; private init; }
    public DateTime CreatedOnUtc { get; private init; }
    private CartProcessingLock( CartID cartId )
       =>  ( Id, CreatedOnUtc ) = ( cartId,  DateTime.UtcNow );

    public static CartProcessingLock Create( CheckoutRequest transaction )
        => new CartProcessingLock( transaction.CartId );

}

