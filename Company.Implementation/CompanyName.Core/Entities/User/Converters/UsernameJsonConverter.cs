// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.User;

public sealed class UsernameJsonConverter : Newtonsoft.Json.JsonConverter<Username>
{
    public override Username ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , Username existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new Username ( ) : new Username ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , Username value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
