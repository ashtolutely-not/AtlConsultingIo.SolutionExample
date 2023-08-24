// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomersRequest : ApiRequest
{
    public int? CustomerID { get; init; }
    public string Company { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public string Phone { get; init; }
    public string Phone2 { get; init; }
    public string MobilePhone { get; init; }
    public string Fax { get; init; }
    public string MainAddress1 { get; init; }
    public string MainAddress2 { get; init; }
    public string MainAddress3 { get; init; }
    public string MainCity { get; init; }
    public string MainState { get; init; }
    public string MainZip { get; init; }
    public string MainCountry { get; init; }
    public string TaxID { get; init; }
    public string SalesTaxID { get; init; }
    public int[] CustomerTypes { get; init; }
    public int[] CustomerStatuses { get; init; }
    public int? EnrollerID { get; init; }
    public int? SponsorID { get; init; }
    public string Field1 { get; init; }
    public string Field10 { get; init; }
    public string Field11 { get; init; }
    public string Field12 { get; init; }
    public string Field13 { get; init; }
    public string Field14 { get; init; }
    public string Field15 { get; init; }
    public string Field2 { get; init; }
    public string Field3 { get; init; }
    public string Field4 { get; init; }
    public string Field5 { get; init; }
    public string Field6 { get; init; }
    public string Field7 { get; init; }
    public string Field8 { get; init; }
    public string Field9 { get; init; }
    public int? GreaterThanCustomerID { get; init; }
    public DateTime? GreaterThanModifiedDate { get; init; }
    public int? BatchSize { get; init; }
    public string LoginName { get; init; }
    public DateTime? CreatedDateEnd { get; init; }
    public DateTime? CreatedDateStart { get; init; }
    public string CustomerKey { get; init; }
    public string EnrollerKey { get; init; }
    public string SponsorKey { get; init; }

    public GetCustomersRequest() : base()
    {
        Company = String.Empty;
        FirstName = String.Empty;
        LastName = String.Empty;
        Email = String.Empty;
        Phone = String.Empty;
        Phone2 = String.Empty;
        MobilePhone = String.Empty;
        Fax = String.Empty;
        MainAddress1 = String.Empty;
        MainAddress2 = String.Empty;
        MainAddress3 = String.Empty;
        MainCity = String.Empty;
        MainState = String.Empty;
        MainZip = String.Empty;
        MainCountry = String.Empty;
        TaxID = String.Empty;
        SalesTaxID = String.Empty;
        CustomerTypes = new int[0];
        CustomerStatuses = new int[0];
        Field1 = String.Empty;
        Field10 = String.Empty;
        Field11 = String.Empty;
        Field12 = String.Empty;
        Field13 = String.Empty;
        Field14 = String.Empty;
        Field15 = String.Empty;
        Field2 = String.Empty;
        Field3 = String.Empty;
        Field4 = String.Empty;
        Field5 = String.Empty;
        Field6 = String.Empty;
        Field7 = String.Empty;
        Field8 = String.Empty;
        Field9 = String.Empty;
        LoginName = String.Empty;
        CustomerKey = String.Empty;
        EnrollerKey = String.Empty;
        SponsorKey = String.Empty;
    }
}
