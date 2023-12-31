// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GuestResponse
{
    public int GuestID { get; init; }
    public int CustomerID { get; init; }
    public int HostID { get; init; }
    public string FirstName { get; init; }
    public string MiddleName { get; init; }
    public string LastName { get; init; }
    public string NameSuffix { get; init; }
    public string Company { get; init; }
    public Gender Gender { get; init; }
    public int GuestStatus { get; init; }
    public int? LanguageID { get; init; }
    public string Address1 { get; init; }
    public string Address2 { get; init; }
    public string Address3 { get; init; }
    public string City { get; init; }
    public string County { get; init; }
    public string State { get; init; }
    public string Zip { get; init; }
    public string Country { get; init; }
    public string Phone { get; init; }
    public string Phone2 { get; init; }
    public string MobilePhone { get; init; }
    public string Email { get; init; }
    public string Field1 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }
    public string Field6 { get; init; }
    public string Field7 { get; init; }
    public string Field8 { get; init; }
    public string Field9 { get; init; }
    public string Field10 { get; init; }
    public string Field11 { get; init; }
    public string Field12 { get; init; }
    public string Field13 { get; init; }
    public string Field14 { get; init; }
    public string Field15 { get; init; }
    public DateTime? Date1 { get; init; }
    public DateTime? Date2 { get; init; }
    public DateTime? Date3 { get; init; }
    public DateTime? Date4 { get; init; }
    public DateTime? Date5 { get; init; }
    public DateTime CreatedDate { get; init; }
    public DateTime ModifiedDate { get; init; }
    public string CustomerKey { get; init; }

    public GuestResponse() : base()
    {
        FirstName = String.Empty;
        MiddleName = String.Empty;
        LastName = String.Empty;
        NameSuffix = String.Empty;
        Company = String.Empty;
        Address1 = String.Empty;
        Address2 = String.Empty;
        Address3 = String.Empty;
        City = String.Empty;
        County = String.Empty;
        State = String.Empty;
        Zip = String.Empty;
        Country = String.Empty;
        Phone = String.Empty;
        Phone2 = String.Empty;
        MobilePhone = String.Empty;
        Email = String.Empty;
        Field1 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
        Field6 = String.Empty;
        Field7 = String.Empty;
        Field8 = String.Empty;
        Field9 = String.Empty;
        Field10 = String.Empty;
        Field11 = String.Empty;
        Field12 = String.Empty;
        Field13 = String.Empty;
        Field14 = String.Empty;
        Field15 = String.Empty;
        CustomerKey = String.Empty;
    }
}
