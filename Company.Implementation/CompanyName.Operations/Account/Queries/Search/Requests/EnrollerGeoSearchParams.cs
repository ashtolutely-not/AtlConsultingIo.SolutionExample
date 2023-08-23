using CompanyName.Operations;
using CompanyName.Operations.Account;
using CompanyName.Operations.Checkout;
using CompanyName.Operations.Messaging;
using CompanyName.Operations.Order;
using CompanyName.Operations.Product;
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
namespace CompanyName.Operations.Account;
public record EnrollerGeoSearchParams 
{
    public string LanguageFilter { get; init; } = String.Empty;
    public string Country { get; init; } = String.Empty;
    public string Region { get; init; } = String.Empty;
    public string FirstNameFilter { get; init; } = String.Empty;
    public string LastNameFilter { get; init; } = String.Empty;

    public object QueryParams()
        => new
        {
            firstName = FirstNameFilter,
            lastName = LastNameFilter,
            region = Region,
            country = Country,
            language = LanguageFilter
        };

    public bool IsEmpty =>
        !LanguageFilter.HasValue() &&
        !Country.HasValue() &&
        !Region.HasValue() &&
        !FirstNameFilter.HasValue() &&
        !LastNameFilter.HasValue();
    public static readonly EnrollerGeoSearchParams Empty = new();
}
