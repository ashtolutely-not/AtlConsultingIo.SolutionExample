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
namespace CompanyName.Core.Integrations.Exigo.Rest;
public enum AccountCreditCardType
{
    Primary = 1,
    Secondary = 2,
}
public enum AccountWalletType
{
    Primary = 1,
    Secondary = 2,
    Third = 3,
    Fourth = 4,
    Fifth = 5,
}
public enum AutoOrderPaymentType
{
    PrimaryCreditCard = 1,
    SecondaryCreditCard = 2,
    CheckingAccount = 3,
    WillSendPayment = 4,
    BankDraft = 5,
    PrimaryWalletAccount = 6,
    SecondaryWalletAccount = 7,
}
public enum AutoOrderProcessType
{
    AlwaysProcess = 1,
    Conditional = 2,
}
public enum AutoOrderStatusType
{
    Active,
    Inactive,
    Deleted,
}
public enum BankAccountType
{
    CheckingPersonal = 1,
    CheckingBusiness = 2,
    SavingsPersonal = 3,
    SavingsBusiness = 4,
}
public enum BannerClickEvent
{
    OpenInNewTab,
    OpenInCurrentWindow,
    None,
}
public enum BannerType
{
    TextOnImage,
    ImageTop,
    InvalidType,
}
public enum BinaryPlacementType
{
    StrategicPlacement = 1,
    BuildLeft = 2,
    BuildRight = 3,
    BalancedBuild = 4,
    EvenFill = 5,
    WeakLeg = 6,
    EnrollerPreference = 7,
    LeftEvenFill = 8,
    RightEvenFill = 9,
    LesserVolumeLeg = 10, // 0x0000000A
    LesserVolumeLegOutside = 11, // 0x0000000B
    StrongLegOutside = 12, // 0x0000000C
    LesserVolumeLegEvenFill = 14, // 0x0000000E
    GreaterVolumeLegEvenFill = 15, // 0x0000000F
    InsertRightMoveDownline = 16, // 0x00000010
    InsertLeftMoveDownline = 17, // 0x00000011
    BuildTeamLeg = 18, // 0x00000012
}
public enum CalendarItemPriorityType
{
    None,
    High,
    Medium,
    Low,
}
public enum CalendarItemStatusType
{
    Open,
    Closed,
}
public enum CalendarItemType
{
    Appointment = 1,
    ToDo = 2,
    Anniversary = 3,
}
public enum CarouselType
{
    Bootstrap3,
    Bootstrap4,
}
public enum ContactPhoneType
{
    Office = 1,
    Mobile = 2,
    Home = 3,
}
public enum CustomerSiteImageType
{
    Primary = 1,
    Secondary = 2,
}
public enum DepositAccountType
{
    Checking = 1,
    Saving = 2,
    Business = 3,
    Personal = 4,
}
public enum FrequencyType
{
    Weekly = 1,
    BiWeekly = 2,
    Monthly = 3,
    Quarterly = 4,
    SemiYearly = 5,
    Yearly = 6,
    BiMonthly = 7,
    EveryFourWeeks = 8,
    EverySixWeeks = 9,
    EveryEightWeeks = 10, // 0x0000000A
    EveryTwelveWeeks = 11, // 0x0000000B
    SpecificDays = 12, // 0x0000000C
}
public enum Gender
{
    Unknown,
    Male,
    Female,
}
public enum InventoryStatusType
{
    Available = 1,
    OnBackOrder = 2,
    OutOfStock = 3,
    Discontinued = 4,
}
public enum InvoiceRenderFormat
{
    HTML = 1,
}
public enum NewsCompanySettings
{
    AccessAllUsers,
    AccessByDepartment,
    AccessNotAvailable,
}
public enum NewsWebSettings
{
    AccessAvailable,
    AccessNotAvailable,
}
public enum NumericCompareType
{
    Equals = 1,
    GreaterThan = 2,
    LessThan = 3,
}
public enum OrderShipCarrier
{
    FedEx = 2,
    UPS = 3,
    Purolator = 4,
    CanadaPostRegular = 5,
    CanadaPostExpress = 6,
    DHL = 20, // 0x00000014
    USPS = 23, // 0x00000017
    Estafeta = 24, // 0x00000018
    RoyalMail = 25, // 0x00000019
    GLSHungary = 27, // 0x0000001B
    PostenNorway = 28, // 0x0000001C
    LandMarkGlobal = 29, // 0x0000001D
    GDEX = 45, // 0x0000002D
}
public enum OrderStatusType
{
    Incomplete,
    Pending,
    CCDeclined,
    ACHDeclined,
    Canceled,
    CCPending,
    ACHPending,
    Accepted,
    Printed,
    Shipped,
    PendingInventory,
}
public enum OrderType
{
    Default,
    CustomerService,
    ShoppingCart,
    WebWizard,
    AutoOrder,
    Import,
    BackOrder,
    ReplacementOrder,
    ReturnOrder,
    WebAutoOrder,
    TicketSystem,
    APIOrder,
    BackOrderParent,
    ChildOrder,
    Other1,
    Other2,
    Other3,
    Other4,
    Other5,
    Other6,
    Other7,
    Other8,
    Other9,
    Other10,
}
[Obsolete("Deprecated 9/1/2021 WID 5418")]
public enum PayableType
{
    Check = 1,
    WireTransfer = 2,
    PaymentCard = 5,
    DirectDeposit = 8,
    OnHold = 10, // 0x0000000A
    BankWire = 11, // 0x0000000B
    DebitCardHold = 15, // 0x0000000F
    Other100 = 100, // 0x00000064
}
public enum PaymentType
{
    Cash,
    CreditCard,
    Check,
    CreditVoucher,
    Net30,
    Net60,
    UseCredit,
    ACHDebit,
    BankDraft,
    BankWire,
    PointRedemtion,
    COD,
    MoneyOrder,
    BankDeposit,
    Other1,
    Other2,
    Other3,
    Wallet,
    Other4,
    Other5,
    Other6,
    Other7,
    Other8,
    Other9,
    Other10,
    Other11,
    Other12,
    Other13,
    Other14,
    Other15,
}
public enum PointTransactionType
{
    Redemption = 2,
    Adjustment = 3,
}
public enum PropertyType
{
    Guid = 36, // 0x00000024
    DateTime2 = 42, // 0x0000002A
    Integer = 56, // 0x00000038
    Decimal = 60, // 0x0000003C
    DateTime = 61, // 0x0000003D
    Boolean = 104, // 0x00000068
    Binary = 165, // 0x000000A5
    String = 231, // 0x000000E7
}
public enum ResourceType
{
    Text,
    Int,
    Decimal,
    Date,
    Boolean,
    DropDown,
    Image,
    Widget,
    Banner,
    DataSet,
    Carousel,
}
public enum ResultStatus
{
    Success,
    Failure,
}
public enum SandboxType
{
    Sandbox = 1,
    Commission = 2,
    Premium = 3,
}
public enum SubscriptionStatus
{
    NotFound,
    Active,
    Expired,
    Cancelled,
}
public enum TaxIDType
{
    SSN = 1,
    EIN = 2,
    OtherType3 = 3,
    OtherType4 = 4,
    OtherType5 = 5,
    OtherType6 = 6,
    OtherType7 = 7,
    OtherType8 = 8,
    OtherType9 = 9,
    OtherType10 = 10, // 0x0000000A
    OtherType11 = 11, // 0x0000000B
    OtherType12 = 12, // 0x0000000C
    OtherType13 = 13, // 0x0000000D
    OtherType14 = 14, // 0x0000000E
    OtherType15 = 15, // 0x0000000F
    OtherType16 = 16, // 0x00000010
    OtherType17 = 17, // 0x00000011
    OtherType18 = 18, // 0x00000012
    OtherType19 = 19, // 0x00000013
    OtherType20 = 20, // 0x00000014
}
public enum TokenAccount
{
    Primary,
    Alternate,
}
public enum TreeType
{
    Enroller = 1,
    UniLevel = 2,
    Binary = 3,
    Matrix = 4,
    Stack = 5,
}
