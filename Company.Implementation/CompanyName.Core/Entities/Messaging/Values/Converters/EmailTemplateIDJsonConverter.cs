// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.Messaging;

public sealed class EmailTemplateIDJsonConverter : Newtonsoft.Json.JsonConverter<EmailTemplateID>
{
    public override EmailTemplateID ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , EmailTemplateID existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new EmailTemplateID ( ) : new EmailTemplateID ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , EmailTemplateID value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
