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
public  struct GuestAccount : ICompanyAccountType
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
            CommerceCloudApiKey = new CommerceCloudPlatformID( "" )
        }
    };
    public CommerceCloudPlatformID CommerceCloudApiKey 
        => new( "" );
    public ExigoTypeID TypeId 
        => new(  );
    public UIDisplayString? Description => new UIDisplayString( "" );

    public static readonly GuestAccount Instance = new();
}
