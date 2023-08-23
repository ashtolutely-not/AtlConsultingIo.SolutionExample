// Generated from source code found in Exigo.Api.Client. 
// Manual modification of files not recommended, could result in errors when using Http Services.
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;

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
