using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
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


namespace CompanyName.Operations.Checkout;

public record CheckoutContext
{
    public bool IsGuestCart { get; init; }
    public bool IsHighDollarCart { get; init; }
    public bool IsEnrollmentCart { get; init; }

    public ICompanyAccountType AccountType { get; init; } = null!;

    public RegistrationProperties? SignupContext { get; init; }
    public PaymentProperties PaymentContext { get; init; } = null!;
    public SmartshipProperties SmartshipContext { get; init; } = null!;
    public ProductProperties ProductContext { get; init; } = null!;

    public List<IOrderPointTransaction>? PointTransactions { get; set; } 

    public static readonly CheckoutContext Default = new();


    public record RegistrationProperties
    {
        public ContactEmail? EmailContact { get; init; }
        public ContactPhoneNumber? PhoneContact { get; init; }
        public string? ShirtSize { get; init; }
    }
    public record ProductProperties
    {
        public int CbdItemCount { get; set; }
        public int EnrollmentKitItemCount { get; set; }
        public int GiftCardItemCount { get; set; }
        public GiftCardInfo[ ]? GiftCardPurchaseDetails { get; set; }
    }
    public record PaymentProperties
    {
        public bool HasHighRiskPayment => RiskInquiryResponse is null || RiskInquiryResponse.IsFraudResponse;
        public GiftCardPayment? GiftCardRedemption { get; set; }
        public List<IOrderPointTransaction>? OrderPointTransactions { get; set; }
        public RiskTransactionResponse? RiskInquiryResponse { get; set; }
    }
    public record SmartshipProperties
    {
        public SmartshipItem[ ]? SmartshipItems { get; set; }
        public DateTime? SmartshipStartDate { get; set; }

    }
}
