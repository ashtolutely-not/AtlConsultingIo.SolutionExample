// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CreateCustomerInquiryRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string Detail { get; init; }
    public string Description { get; init; }
    public string AssignToUser { get; init; }
    public int CustomerInquiryStatusID { get; init; }
    public int CustomerInquiryCategoryID { get; init; }
    public string CustomerKey { get; init; }
    public int? ParentID { get; init; }

    public CreateCustomerInquiryRequest() : base()
    {
        Detail = String.Empty;
        Description = String.Empty;
        AssignToUser = String.Empty;
        CustomerKey = String.Empty;
    }
}
