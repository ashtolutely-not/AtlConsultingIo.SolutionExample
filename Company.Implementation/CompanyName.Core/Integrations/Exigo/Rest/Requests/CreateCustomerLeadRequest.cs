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
public record CreateCustomerLeadRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public string Company { get; init; }
    public string Phone { get; init; }
    public string Phone2 { get; init; }
    public string MobilePhone { get; init; }
    public string Fax { get; init; }
    public string Email { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string City { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public DateTime? BirthDate { get; init; }
    public string Notes { get; init; }
    public string CustomerKey { get; init; }

    public CreateCustomerLeadRequest() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        MiddleName = String.Empty;
        Company = String.Empty;
        Phone = String.Empty;
        Phone2 = String.Empty;
        MobilePhone = String.Empty;
        Fax = String.Empty;
        Email = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        Notes = String.Empty;
        CustomerKey = String.Empty;
    }
}
