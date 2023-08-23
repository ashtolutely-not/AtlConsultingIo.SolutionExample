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

public record TotalLifePriceType : IExigoPriceType
{
    public ExigoTypeID TypeID { get; init; }
    public UIDisplayString? Description { get; init; }
    public bool IsRecurringOrderPrice { get; init; }
    public bool IsEnrollmentOrderPrice { get; init; }
    public CommerceCloudPlatformID CommerceCloudApiKey { get; init; }

    public static IEnumerable<TotalLifePriceType> Values => ICompanyAccountType.Values.SelectMany( x => x.PriceTypes);
}

