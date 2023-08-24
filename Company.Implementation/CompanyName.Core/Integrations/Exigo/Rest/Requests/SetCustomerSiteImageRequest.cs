// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.

namespace CompanyName.Core.Integrations.Exigo.Rest;
public record SetCustomerSiteImageRequest : ApiRequest
{
    public int CustomerID { get; init; }
    public string ImageName { get; init; }
    public byte[] ImageData { get; init; }
    public CustomerSiteImageType CustomerSiteImageType { get; init; }
    public string CustomerKey { get; init; }

    public SetCustomerSiteImageRequest() : base()
    {
        ImageName = String.Empty;
        ImageData = new byte[0];
        CustomerKey = String.Empty;
    }
}
