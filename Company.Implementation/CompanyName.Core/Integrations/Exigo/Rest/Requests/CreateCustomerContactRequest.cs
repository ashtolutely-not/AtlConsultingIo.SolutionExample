// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateCustomerContactRequest : ApiRequest, ITransactionMember
{
    public int CustomerID { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string MiddleName { get; init; }
    public string Company { get; init; }
    public string BusinessPhone { get; init; }
    public string HomePhone { get; init; }
    public string Mobile { get; init; }
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
    public string LinkedIn { get; init; }
    public string Facebook { get; init; }
    public string Blog { get; init; }
    public string MySpace { get; init; }
    public string GooglePlus { get; init; }
    public string Twitter { get; init; }
    public string CustomerKey { get; init; }

    public CreateCustomerContactRequest() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        MiddleName = String.Empty;
        Company = String.Empty;
        BusinessPhone = String.Empty;
        HomePhone = String.Empty;
        Mobile = String.Empty;
        Fax = String.Empty;
        Email = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        City = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        Notes = String.Empty;
        LinkedIn = String.Empty;
        Facebook = String.Empty;
        Blog = String.Empty;
        MySpace = String.Empty;
        GooglePlus = String.Empty;
        Twitter = String.Empty;
        CustomerKey = String.Empty;
    }
}
