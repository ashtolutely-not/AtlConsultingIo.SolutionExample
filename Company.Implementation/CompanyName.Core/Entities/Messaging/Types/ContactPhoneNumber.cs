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

namespace CompanyName.Core.Entities.Messaging;

public record ContactPhoneNumber : IUserContact
{
    public CustomerID UserID { get; init; }
    public PhoneNumber PhoneNumber { get; init; } = PhoneNumber.Default;
    public Enabled IsSubscribed { get; init; }

    public string Value => PhoneNumber.CleanValue.Value;
}
