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

namespace CompanyName.Core.Integrations.Exigo;
public struct AffiliateAccount : ICompanyAccountType
{
    public bool EnrollerRequiredOnCreate => true;
    public bool DailyPayAutoEnabled => true;
    public bool HasBirthdateRequirement => true;
    public bool TaxIDRequiredOnCreate => true;
    public bool SmartshipDisplayOptionEnabled => PriceTypes.Any( i => i.IsRecurringOrderPrice );
    public List<ShoppingSiteDomain> LogInEnabledSites => new();

    public List<TotalLifePriceType> PriceTypes => new ()
    {
        new()
        {
            TypeID = new ExigoTypeID(  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID( "" )
        },
        new()
        {
            TypeID = new ExigoTypeID(  ),
            CommerceCloudApiKey = new CommerceCloudPlatformID( "" ),
            IsEnrollmentOrderPrice = true
        }
    };
    public CommerceCloudPlatformID CommerceCloudApiKey => new( "" );
    public ExigoTypeID TypeId => new( );
    public UIDisplayString? Description => new UIDisplayString("");

    public static readonly AffiliateAccount Instance = new();
}
