using CompanyName.Core.Integrations.Exigo;

namespace CompanyName.Core.Entities.Messaging;

public interface IUserContact
{
    CustomerID UserID { get; }
    string Value { get; }
    Enabled IsSubscribed { get; }
}
