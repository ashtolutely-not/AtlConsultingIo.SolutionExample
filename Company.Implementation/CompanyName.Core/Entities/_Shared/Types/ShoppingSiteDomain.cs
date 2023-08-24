using CompanyName.Core.Integrations.Exigo;
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
