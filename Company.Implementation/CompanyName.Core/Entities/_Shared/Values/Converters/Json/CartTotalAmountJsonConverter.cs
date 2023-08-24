// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class CartTotalAmountJsonConverter : Newtonsoft.Json.JsonConverter<ShoppingCartTotal>
{
    public override ShoppingCartTotal ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , ShoppingCartTotal existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<decimal?> ( reader ) is not decimal _value ? new ShoppingCartTotal ( ) : new ShoppingCartTotal ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , ShoppingCartTotal value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
