// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities;

public sealed class DayOfMonthJsonConverter : Newtonsoft.Json.JsonConverter<DayOfMonth>
{
    public override DayOfMonth ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , DayOfMonth existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<int?> ( reader ) is not int _value ? new DayOfMonth ( ) : new DayOfMonth ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , DayOfMonth value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
