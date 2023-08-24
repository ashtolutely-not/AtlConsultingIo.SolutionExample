// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record UpdateCustomerContactResponse : ApiResponse
{
    public int CustomerID { get; init; }
    public int CustomerContactID { get; init; }
    public string CustomerKey { get; init; }

    public UpdateCustomerContactResponse( ) : base ( ) => CustomerKey = String.Empty;
}
