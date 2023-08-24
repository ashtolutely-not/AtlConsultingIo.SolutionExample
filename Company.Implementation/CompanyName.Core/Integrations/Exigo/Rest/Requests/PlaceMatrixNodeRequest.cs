// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

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
