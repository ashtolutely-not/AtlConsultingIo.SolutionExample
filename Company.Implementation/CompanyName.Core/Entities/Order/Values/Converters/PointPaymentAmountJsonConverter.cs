// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.Order;

public sealed class PointPaymentAmountJsonConverter : Newtonsoft.Json.JsonConverter<PointAcccountPaymentAmount>
{
    public override PointAcccountPaymentAmount ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , PointAcccountPaymentAmount existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<decimal?> ( reader ) is not decimal _value ? new PointAcccountPaymentAmount ( ) : new PointAcccountPaymentAmount ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , PointAcccountPaymentAmount value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
