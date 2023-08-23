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
using System.Runtime.Serialization;

namespace CompanyName.Core.Integrations.KountApi;

public enum KountUpdateType
{
    [EnumMember(Value = "U")]
    UpdateOnly,
    [EnumMember(Value = "X")]
    UpdateAndAnalyze,
    [EnumMember(Value = "E")]
    ErrorUpdate
}

public enum AutomatedResponseType
{
    Unknown,
    [EnumMember(Value = "R")]
    NeedsReview = 'R',
    [EnumMember(Value = "A")]
    Approved = 'A',
    [EnumMember(Value = "D")]
    Declined = 'D'
}

public enum KountInquiryType
{
    [EnumMember(Value = "Q")]
    WebOrderInquiry,
    [EnumMember(Value = "P")]
    PhoneOrderInquiry,
    [EnumMember(Value = "W")]
    ModeW,
    [EnumMember(Value = "J")]
    ModeJ
}

public enum KountPaymentType
{
    Default,
    [EnumMember(Value = "APAY")]
    Apple,
    [EnumMember(Value = "BLML")]
    BillMeLater,
    [EnumMember(Value = "BPAY")]
    Bpay,
    [EnumMember(Value = "CARD")]
    CreditCard,
    [EnumMember(Value = "CARTE_BLEUE")]
    CarteBleue,
    [EnumMember(Value = "CHEK")]
    Check,
    [EnumMember(Value = "ELV")]
    Elv,
    [EnumMember(Value = "GDMP")]
    GreenDotMoneyPak,
    [EnumMember(Value = "GIFT")]
    GiftCard,
    [EnumMember(Value = "GIROPAY")]
    GiroPay,
    [EnumMember(Value = "GOOG")]
    Google,
    [EnumMember(Value = "INTERAC")]
    Interac,
    [EnumMember(Value = "MERCADE_PAGO")]
    MercadePago,
    [EnumMember(Value = "NETELLER")]
    Neteller,
    [EnumMember(Value = "NONE")]
    None,
    [EnumMember(Value = "POLI")]
    Poli,
    [EnumMember(Value = "PYPL")]
    Paypal,
    [EnumMember(Value = "SEPA")]
    SingleEuroPaymentsArea,
    [EnumMember(Value = "SKRILL")]
    Skrill,
    [EnumMember(Value = "SOFORT")]
    Sofort,
    [EnumMember(Value = "TOKEN")]
    Token
}
