// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Integrations.Exigo;

public sealed class ExigoSystemIDJsonConverter : Newtonsoft.Json.JsonConverter<ExigoTypeID>
{
    public override ExigoTypeID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , ExigoTypeID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<int?> ( reader ) is not int _value ? new ExigoTypeID ( ) : new ExigoTypeID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , ExigoTypeID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
