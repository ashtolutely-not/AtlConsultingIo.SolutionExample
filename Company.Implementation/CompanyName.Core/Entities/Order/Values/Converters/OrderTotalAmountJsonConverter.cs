// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.Order;

public sealed class OrderTotalAmountJsonConverter : Newtonsoft.Json.JsonConverter<SalesOrderTotal>
{
    public override SalesOrderTotal ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , SalesOrderTotal existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<decimal?> ( reader ) is not decimal _value ? new SalesOrderTotal ( ) : new SalesOrderTotal ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , SalesOrderTotal value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
