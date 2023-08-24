// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class TwoLetterISOCodeJsonConverter : Newtonsoft.Json.JsonConverter<TwoLetterISOCode>
{
    public override TwoLetterISOCode ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , TwoLetterISOCode existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new TwoLetterISOCode ( ) : TwoLetterISOCode.Parse ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , TwoLetterISOCode value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
