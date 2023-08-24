using CompanyName.Core.Entities;

namespace CompanyName.Core.Integrations.Exigo;

public interface ICompanyAccountType : IExigoCustomerType
{
    bool EnrollerRequiredOnCreate { get; }
    bool DailyPayAutoEnabled { get; }
    bool HasBirthdateRequirement { get; }
    bool TaxIDRequiredOnCreate { get; }
    bool SmartshipDisplayOptionEnabled { get; }
    List<TotalLifePriceType> PriceTypes { get; }
    List<ShoppingSiteDomain> LogInEnabledSites { get; }
    CommerceCloudPlatformID CommerceCloudApiKey { get; }

    public static readonly List<ICompanyAccountType> Values = new ()
    {
        AffiliateAccount.Instance,
        DistributorAccount.Instance,
        GuestAccount.Instance,
        RetailCustomerAccount.Instance
    };
}

