// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.User;

public sealed class IncomeTaxIDJsonConverter : Newtonsoft.Json.JsonConverter<IncomeTaxID>
{
    public override IncomeTaxID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , IncomeTaxID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new IncomeTaxID ( ) : new IncomeTaxID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , IncomeTaxID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
