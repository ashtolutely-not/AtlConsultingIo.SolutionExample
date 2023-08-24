using CompanyName.Core.Integrations.Exigo.Sql;


namespace CompanyName.Core.Integrations.Exigo;

public struct ExigoCustomOrderFields
{
    public const string CartID = nameof(Order.Other18);
    public const string HasHighRiskPaymentMethod = nameof(Order.Other17);
}


public struct ExigoCustomAccountFields
{
    public const string UpgradeDate = nameof(Customer.Date5);
}
