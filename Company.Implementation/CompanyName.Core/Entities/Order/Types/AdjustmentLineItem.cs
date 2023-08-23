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

public record AdjustmentLineItem
{
    public decimal? DiscountValue { get; init; }
    public string? ProductLineId { get; init; }
    public string? AdjustmentId { get; init; }
    public string? DiscountType { get; init; }
    public string? CouponCode { get; init; }
    public string? PromotionId { get; init; }

    public static readonly AdjustmentLineItem Empty = new();
    public bool IsEmpty => Equals( Empty );
}
