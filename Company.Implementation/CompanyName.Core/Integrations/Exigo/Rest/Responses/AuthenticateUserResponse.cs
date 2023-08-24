// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record AuthenticateUserResponse : ApiResponse
{
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public AuthenticateUserResponse() : base()
    {
        FirstName = String.Empty;
        LastName = String.Empty;
    }
}
