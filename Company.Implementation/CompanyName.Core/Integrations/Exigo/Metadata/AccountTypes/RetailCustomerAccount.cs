using CompanyName.Core.Entities;
namespace CompanyName.Core.Integrations.Exigo;
public struct RetailCustomerAccount : ICompanyAccountType
{
    public bool EnrollerRequiredOnCreate => false;
    public bool DailyPayAutoEnabled => false;
    public bool HasBirthdateRequirement => false;
    public bool TaxIDRequiredOnCreate => false;
    public bool SmartshipDisplayOptionEnabled => PriceTypes.Any( i => i.IsRecurringOrderPrice );
    public List<ShoppingSiteDomain> LogInEnabledSites => new();
    public List<TotalLifePriceType> PriceTypes => new()
    {
        new TotalLifePriceType
        {
            TypeID = new ExigoTypeID(  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID( "" ),
        },
        new TotalLifePriceType
        {
            TypeID = new ExigoTypeID (  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID(""),
            IsRecurringOrderPrice = true,
        }
    };
    public CommerceCloudPlatformID CommerceCloudApiKey => new("");
    public ExigoTypeID TypeId => new(  );
    public UIDisplayString? Description => new UIDisplayString( "" );

    public static readonly RetailCustomerAccount Instance = new();
}
