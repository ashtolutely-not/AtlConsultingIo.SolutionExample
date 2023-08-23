// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
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

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerSiteResponse : ApiResponse
{
    public int CustomerID { get; init; }
    public string WebAlias { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Company { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Phone2 { get; init; }
    public string Fax { get; init; }
    public string Notes1 { get; init; }
    public string Notes2 { get; init; }
    public string Notes3 { get; init; }
    public string Notes4 { get; init; }
    public string Url1 { get; init; }
    public string Url2 { get; init; }
    public string Url3 { get; init; }
    public string Url4 { get; init; }
    public string Url5 { get; init; }
    public string Url6 { get; init; }
    public string Url7 { get; init; }
    public string Url8 { get; init; }
    public string Url9 { get; init; }
    public string Url10 { get; init; }
    public string Url1Description { get; init; }
    public string Url2Description { get; init; }
    public string Url3Description { get; init; }
    public string Url4Description { get; init; }
    public string Url5Description { get; init; }
    public string Url6Description { get; init; }
    public string Url7Description { get; init; }
    public string Url8Description { get; init; }
    public string Url9Description { get; init; }
    public string Url10Description { get; init; }
    public string Image1 { get; init; }
    public string Image2 { get; init; }
    public string ImageUrl1 { get; init; }
    public string ImageUrl2 { get; init; }
    public string CustomerKey { get; init; }

    public GetCustomerSiteResponse() : base()
    {
        WebAlias = String.Empty;
        FirstName = String.Empty;
        LastName = String.Empty;
        Company = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        Phone2 = String.Empty;
        Fax = String.Empty;
        Notes1 = String.Empty;
        Notes2 = String.Empty;
        Notes3 = String.Empty;
        Notes4 = String.Empty;
        Url1 = String.Empty;
        Url2 = String.Empty;
        Url3 = String.Empty;
        Url4 = String.Empty;
        Url5 = String.Empty;
        Url6 = String.Empty;
        Url7 = String.Empty;
        Url8 = String.Empty;
        Url9 = String.Empty;
        Url10 = String.Empty;
        Url1Description = String.Empty;
        Url2Description = String.Empty;
        Url3Description = String.Empty;
        Url4Description = String.Empty;
        Url5Description = String.Empty;
        Url6Description = String.Empty;
        Url7Description = String.Empty;
        Url8Description = String.Empty;
        Url9Description = String.Empty;
        Url10Description = String.Empty;
        Image1 = String.Empty;
        Image2 = String.Empty;
        ImageUrl1 = String.Empty;
        ImageUrl2 = String.Empty;
        CustomerKey = String.Empty;
    }
}
