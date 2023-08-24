// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerLeadsRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public int? CustomerLeadID { get; init; }
    public int? GreaterThanCustomerLeadID { get; init; }
    public int? BatchSize { get; init; }
    public string CustomerKey { get; init; }

    public GetCustomerLeadsRequest( ) : base ( ) => CustomerKey = String.Empty;
}
