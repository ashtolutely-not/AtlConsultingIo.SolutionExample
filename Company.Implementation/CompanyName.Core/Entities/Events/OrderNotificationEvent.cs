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

public record OrderNotificationEvent : IEventData
{
    public CustomerID UserId { get; private init; }
    public OrderID OrderId { get; private init; }
    public EmailTemplateID EmailId { get; private init; }

    [JsonProperty]
    public DateTime SendDate { get; private init; } = DateTime.UtcNow;
    public string EventId => string.Join('_', UserId, OrderId, EmailId );

    private OrderNotificationEvent() { }
    public OrderNotificationEvent( CustomerID userId, OrderID orderId, EmailTemplateID templateId )
    {
        UserId = userId;
        OrderId = orderId;
        EmailId = templateId;
    }
}
