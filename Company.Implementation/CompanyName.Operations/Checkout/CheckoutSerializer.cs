using CompanyName.Core.Entities.User;

using Newtonsoft.Json.Linq;
namespace CompanyName.Operations.Checkout;
internal static class CheckoutSerializer
{
    private static readonly Newtonsoft.Json.JsonSerializer _serializer = Newtonsoft.Json.JsonSerializer.Create(new Newtonsoft.Json.JsonSerializerSettings
    {
        Converters = new[] { new PointTransactionConverter() }
    });

    public static JObject GetBlobJson( CheckoutState state )
        => JObject.FromObject( state, _serializer );
}
