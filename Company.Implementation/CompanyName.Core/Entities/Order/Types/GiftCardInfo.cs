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
