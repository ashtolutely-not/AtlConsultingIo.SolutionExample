// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class CstJsonConverter : Newtonsoft.Json.JsonConverter<CstDateTime>
{
    public override CstDateTime ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , CstDateTime existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<DateTime?> ( reader ) is not DateTime _value ? new CstDateTime ( ) : new CstDateTime ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , CstDateTime value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
