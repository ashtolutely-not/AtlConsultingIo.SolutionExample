using CompanyName.Core.Entities;
namespace CompanyName.Core.Integrations.Exigo;
public struct DistributorAccount : ICompanyAccountType
{
    public bool EnrollerRequiredOnCreate => true;
    public bool DailyPayAutoEnabled => false;
    public bool HasBirthdateRequirement => true;
    public bool TaxIDRequiredOnCreate => true;
    public bool SmartshipDisplayOptionEnabled => PriceTypes.Any( i => i.IsRecurringOrderPrice );
    public List<ShoppingSiteDomain> LogInEnabledSites => new();
    public List<TotalLifePriceType> PriceTypes => new()
    {
        new()
        {
            TypeID = new ExigoTypeID(  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID( "" )
        },
        new()
        {
            TypeID = new ExigoTypeID(  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID(""),
            IsRecurringOrderPrice = true
        },
        new()
        {
            TypeID = new ExigoTypeID(  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID(""),
            IsEnrollmentOrderPrice = true
        }
    };
    public CommerceCloudPlatformID CommerceCloudApiKey => new( "" );
    public ExigoTypeID TypeId => new(  );
    public UIDisplayString? Description => new UIDisplayString( "" );

    public static readonly DistributorAccount Instance = new();
}
