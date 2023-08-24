// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record CustomerLeadSocialNetworkRequest
{
    public int SocialNetworkID { get; init; }
    public string Url { get; init; }

    public CustomerLeadSocialNetworkRequest( ) : base ( ) => Url = String.Empty;
}
