using CompanyName.Core.Integrations.Exigo;
namespace CompanyName.Core.Entities.User;

public record UserSite
{
    public CustomerID UserId { get;  init; }
    public string SiteAlias { get;  init; }
    public string SiteEmail { get;  init; }
    public string SitePhone { get;  init; }
    public UserSiteUrl? Url { get;  set; }

    public bool IsDefault => Equals( Default );
    public UserSite() 
        => SiteAlias = SiteEmail = SitePhone = string.Empty;

    public static readonly UserSite Default = new();

}
