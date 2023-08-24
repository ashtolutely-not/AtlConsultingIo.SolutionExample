// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record GetRandomMessageResponse : ApiResponse
{
    public int RandomMessageID { get; init; }
    public string Content { get; init; }

    public GetRandomMessageResponse( ) : base ( ) => Content = String.Empty;
}
