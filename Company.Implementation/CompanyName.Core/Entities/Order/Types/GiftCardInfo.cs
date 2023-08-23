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

public record GiftCardInfo
{
    public string SenderName { get; init; }
    public string RecipientName { get; init; }
    public string RecipientEmail { get; init; }
    public decimal GiftCertificateValue { get; init; }
    public string GiftCertificateCode { get; init; }
    public string Message { get; init; }

    public static readonly GiftCardInfo Default = new();
    public bool IsDefault => Equals( Default );

    public GiftCardInfo()
    {
        SenderName = RecipientName = RecipientEmail = string.Empty;
        GiftCertificateCode = Message = string.Empty;
    }

}
