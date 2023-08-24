// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.Order;

public sealed class PaymentChargeAmountJsonConverter : Newtonsoft.Json.JsonConverter<PaymentAccountChargeAmount>
{
    public override PaymentAccountChargeAmount ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , PaymentAccountChargeAmount existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<decimal?> ( reader ) is not decimal _value ? new PaymentAccountChargeAmount ( ) : IDecimalValue.Create<PaymentAccountChargeAmount> ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , PaymentAccountChargeAmount value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
