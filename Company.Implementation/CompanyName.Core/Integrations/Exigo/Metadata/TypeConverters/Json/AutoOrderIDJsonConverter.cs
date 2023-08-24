// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Integrations.Exigo;
public sealed class AutoOrderIDJsonConverter : Newtonsoft.Json.JsonConverter<AutoOrderID>
{
    public override AutoOrderID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , AutoOrderID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<int?> ( reader ) is not int _value ? new AutoOrderID ( ) : new AutoOrderID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , AutoOrderID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
