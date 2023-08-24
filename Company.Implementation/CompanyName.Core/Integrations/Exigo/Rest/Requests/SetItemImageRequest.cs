// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetItemImageRequest : ApiRequest
{
    public string ItemCode { get; init; }
    public string TinyImageName { get; init; }
    public byte[] TinyImageData { get; init; }
    public string SmallImageName { get; init; }
    public byte[] SmallImageData { get; init; }
    public string LargeImageName { get; init; }
    public byte[] LargeImageData { get; init; }

    public SetItemImageRequest() : base()
    {
        ItemCode = String.Empty;
        TinyImageName = String.Empty;
        TinyImageData = new byte[0];
        SmallImageName = String.Empty;
        SmallImageData = new byte[0];
        LargeImageName = String.Empty;
        LargeImageData = new byte[0];
    }
}
