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
public record PlaceMatrixNodeRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int ToParentCustomerID { get; init; }
    public int? ToParentMatrixID { get; init; }
    public string Reason { get; init; }
    public int Placement { get; init; }
    public string CustomerKey { get; init; }
    public string ToParentCustomerKey { get; init; }
    public string ToParentMatrixKey { get; init; }

    public PlaceMatrixNodeRequest() : base()
    {
        Reason = String.Empty;
        CustomerKey = String.Empty;
        ToParentCustomerKey = String.Empty;
        ToParentMatrixKey = String.Empty;
    }
}
