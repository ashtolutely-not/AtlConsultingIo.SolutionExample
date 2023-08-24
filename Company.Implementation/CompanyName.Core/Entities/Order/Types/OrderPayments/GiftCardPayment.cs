using CompanyName.Core.Integrations.Exigo;

namespace CompanyName.Core.Entities.Order;
public record GiftCardPayment 
{
    public CartID CartId { get; init; }
    public CustomerID? UserId { get; init; }
    public OrderID? OrderId { get; init; }
    public ExigoTypeID? PaymentRecordId { get; init; }
    public DateTime? TransactionDate { get; init; } = CstDateTime.Now;
    public GiftCardInfo? GiftCard { get; init; }
    public decimal Amount { get; init; }
    public string? ProcessingError { get; init; }
    public string Reference => $"GiftCardNumber: {( GiftCard != null ? GiftCard.GiftCertificateCode : PrintString.Null )}";
    public GiftCardPayment( CartID cartId,  decimal amount, GiftCardInfo? giftCard )
    {
        CartId = cartId;
        GiftCard = giftCard;
        Amount = amount;
    }

}
