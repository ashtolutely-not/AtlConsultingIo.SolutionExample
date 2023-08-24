// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerExtendedResponse : ApiResponse
{
    public CustomerExtendedResponse[] Items { get; init; }

    public GetCustomerExtendedResponse( ) : base ( ) => Items = new CustomerExtendedResponse[ 0 ];
}
