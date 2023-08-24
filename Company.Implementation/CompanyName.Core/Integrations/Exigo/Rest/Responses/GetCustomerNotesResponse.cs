// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetCustomerNotesResponse : ApiResponse
{
    public CustomerNotesResponse[] CustomerNotes { get; init; }

    public GetCustomerNotesResponse( ) : base ( ) => CustomerNotes = new CustomerNotesResponse[ 0 ];
}
