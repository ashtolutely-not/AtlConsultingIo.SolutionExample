// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.
using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;

namespace CompanyName.Core.Entities;

public sealed class StringValueJsonConverter : Newtonsoft.Json.JsonConverter<PrintString>
{
    public override PrintString ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , PrintString existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new PrintString ( ) : IStringValue.Create<PrintString> ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , PrintString value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
