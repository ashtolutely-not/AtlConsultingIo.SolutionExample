using CompanyName.Core.Entities.Order;
using CompanyName.Core.Integrations.Exigo;
namespace CompanyName.Core.Entities.Events;

public record GiftCardNotificationEvent : IEventData
{
    public OrderID OrderID { get; private init; }
    public GiftCardInfo GiftCard { get; private init; } = GiftCardInfo.Default;
    public DateTime SendDate { get; private init; } = DateTime.UtcNow;
    public GiftCardNotificationEvent() { }
    public GiftCardNotificationEvent( OrderID orderID, GiftCardInfo giftCard)
    {
        OrderID = orderID;
        GiftCard = giftCard;
    }
    public string EventId => string.Join('_', OrderID, GiftCard.GiftCertificateCode );
}
