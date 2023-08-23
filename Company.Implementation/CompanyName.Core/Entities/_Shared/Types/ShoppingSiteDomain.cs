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
namespace CompanyName.Core.Entities;

public record ShoppingSiteDomain
{
    public string SiteKey { get; init; } 
    public string SiteDomain { get; init; }
    public bool IsInfluencerSite { get; init; }
    public bool IsCampaignSite { get; init; }
    public CustomerID DefaultEnroller { get; init; }
    public ShoppingSiteDomain( ) => SiteKey = SiteDomain = String.Empty;
    public ShoppingSiteDomain AsInfluencerSite()
        => this with { IsInfluencerSite = true };

    public ShoppingSiteDomain AsCampaignSite()
        => this with { IsCampaignSite = true };

    public static readonly ShoppingSiteDomain[] Values 
            = new ShoppingSiteDomain[]
            {
                new ShoppingSiteDomain { SiteKey = "core", SiteDomain = "shop.totallifechanges.com" },
                new ShoppingSiteDomain { SiteKey = "pi", SiteDomain = "www.shoptlcnow.com" }.AsInfluencerSite(),
                new ShoppingSiteDomain
                {
                   SiteKey = "Sites-TLC-MHM-Site",
                   SiteDomain = "www.the15daychallengekit.com", 
                   DefaultEnroller = new CustomerID(115)
                }.AsCampaignSite()
            };
}
