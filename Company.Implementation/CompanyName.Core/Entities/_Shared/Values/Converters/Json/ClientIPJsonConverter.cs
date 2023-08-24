// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class ClientIPJsonConverter : Newtonsoft.Json.JsonConverter<CheckoutIP>
{
    public override CheckoutIP ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , CheckoutIP existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new CheckoutIP ( ) : new CheckoutIP ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , CheckoutIP value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
