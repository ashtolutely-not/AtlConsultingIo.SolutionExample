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
