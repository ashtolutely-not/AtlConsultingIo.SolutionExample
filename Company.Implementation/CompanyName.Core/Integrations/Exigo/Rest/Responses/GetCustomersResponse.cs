// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomersResponse : ApiResponse
{
    public CustomerResponse[] Customers { get; init; }
    public int RecordCount { get; init; }

    public GetCustomersResponse( ) : base ( ) => Customers = new CustomerResponse[ 0 ];
}
