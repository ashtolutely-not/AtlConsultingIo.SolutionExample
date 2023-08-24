// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class StringValueJsonConverter : Newtonsoft.Json.JsonConverter<PrintString>
{
    public override PrintString ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , PrintString existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new PrintString ( ) : IStringValue.Create<PrintString> ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , PrintString value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
