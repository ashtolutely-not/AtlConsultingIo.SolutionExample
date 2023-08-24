// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Integrations.Exigo;

public sealed class PointAccountIDJsonConverter : Newtonsoft.Json.JsonConverter<PointAccountID>
{
    public override PointAccountID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , PointAccountID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<int?> ( reader ) is not int _value ? new PointAccountID ( ) : new PointAccountID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , PointAccountID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
