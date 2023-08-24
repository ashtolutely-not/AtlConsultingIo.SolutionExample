// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Integrations.Exigo;

public sealed class CustomerIDJsonConverter : Newtonsoft.Json.JsonConverter<CustomerID>
{
    public override CustomerID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , CustomerID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<int?> ( reader ) is not int _value ? new CustomerID ( ) : new CustomerID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , CustomerID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
