namespace CompanyName.Operations.Checkout;

public struct ValidationContextKeys
{
    public const string Context = nameof(CheckoutContext);
    public const string OrderRules = nameof(SalesOrderRules);
    public const string AccountRules = nameof(AccountRegistrationRules);
    public const string SmartshipRules = nameof(SmartshipScheduleRules);
    public const string ExigoConfiguration = nameof(ExigoConfiguration);
}
