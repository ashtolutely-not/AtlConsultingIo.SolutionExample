// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetLoginSessionResponse : ApiResponse
{
    public int CustomerID { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string CustomerKey { get; init; }

    public GetLoginSessionResponse() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
        CustomerKey = String.Empty;
    }
}
