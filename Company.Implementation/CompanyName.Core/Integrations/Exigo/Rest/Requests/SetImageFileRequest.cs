// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetImageFileRequest : ApiRequest
{
    public string Path { get; init; }
    public string Name { get; init; }
    public byte[] ImageData { get; init; }

    public SetImageFileRequest() : base()
    {
        Path = String.Empty;
        Name = String.Empty;
        ImageData = new byte[0];
    }
}
