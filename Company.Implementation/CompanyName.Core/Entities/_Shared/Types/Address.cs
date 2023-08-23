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
public readonly record struct Address
{
    public static readonly Address Default = new();
    public bool IsDefault => Equals( Default );
    public bool IsVerified { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string City { get; init; }
    public string Region { get; init; }
    public string PostalCode { get; init; }
    public string Country { get; init; }

    public Address( string? address1 , string? address2 , string? address3 , string? city , string? region , string? country , string? postalCode , bool isVerified = false )
    {
        Address1 = address1 ?? String.Empty;
        Address2 = address2 ?? String.Empty;
        Address3 = address3 ?? String.Empty;
        City = city ?? String.Empty;
        Region = region ?? String.Empty;
        Country = country ?? String.Empty;
        PostalCode = postalCode ?? String.Empty;
        IsVerified = isVerified;
    }

    public string StreetAddress()
    {
        List<string> list = new()
        {
                Address1.Trim(),
                Address2.Trim(),
                Address3.Trim()
            };

        list.RemoveAll( string.IsNullOrWhiteSpace );
        return list.Any() ? string.Join( ';' , list ) : String.Empty;
    }
}
