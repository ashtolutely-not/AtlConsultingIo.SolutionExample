// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Integrations.Exigo;

public sealed class OrderIDJsonConverter : Newtonsoft.Json.JsonConverter<OrderID>
{
    public override OrderID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , OrderID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<int?> ( reader ) is not int _value ? new OrderID ( ) : new OrderID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , OrderID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
