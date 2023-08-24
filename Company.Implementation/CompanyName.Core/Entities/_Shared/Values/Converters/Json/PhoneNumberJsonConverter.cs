// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class PhoneNumberJsonConverter : Newtonsoft.Json.JsonConverter<PhoneNumber>
{
    public override PhoneNumber ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , PhoneNumber? existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? PhoneNumber.Default : PhoneNumber.Parse ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , PhoneNumber? value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value is null ? String.Empty : value.DisplayValue );
}
