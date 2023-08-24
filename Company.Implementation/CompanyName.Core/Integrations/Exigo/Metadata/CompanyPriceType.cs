using CompanyName.Core.Entities;
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

