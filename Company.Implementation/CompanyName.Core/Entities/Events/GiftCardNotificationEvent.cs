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
