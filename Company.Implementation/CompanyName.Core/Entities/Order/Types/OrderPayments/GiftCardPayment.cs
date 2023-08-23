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
