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
