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
