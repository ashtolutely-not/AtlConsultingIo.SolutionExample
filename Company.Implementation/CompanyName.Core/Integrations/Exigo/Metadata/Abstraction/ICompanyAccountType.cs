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

