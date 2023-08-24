// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.Order;

public sealed class IsProcessedJsonConverter : Newtonsoft.Json.JsonConverter<OrderTasksCanExecute>
{
    public override OrderTasksCanExecute ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , OrderTasksCanExecute existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<bool?> ( reader ) is not bool _value ? new OrderTasksCanExecute ( ) : IBooleanValue.Create<OrderTasksCanExecute> ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , OrderTasksCanExecute value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
