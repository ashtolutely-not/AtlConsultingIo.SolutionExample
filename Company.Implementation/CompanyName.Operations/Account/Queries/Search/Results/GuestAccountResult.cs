using CompanyName.Core.Integrations.Exigo;

namespace CompanyName.Operations.Account;

public record GuestAccountMatch
{
    public CustomerID? GuestCustomerID { get; init; }
    public CustomerID? SiteOwnerID { get; init; }

    public static readonly GuestAccountMatch None = new();
    public bool IsEmpty => Equals( None );
}
