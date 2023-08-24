// Code generated using Roslyn API's. 
// Generator assumes decorated types are record structs with a property named Value that holds the framework provided value type.
// Modification of these types after generation could have unintended consequences.

namespace CompanyName.Core.Entities.User;

public sealed class UserSiteUrlJsonConverter : Newtonsoft.Json.JsonConverter<UserSiteUrl>
{
    public override UserSiteUrl ReadJson( Newtonsoft.Json.JsonReader reader , Type objectType , UserSiteUrl existingValue , bool hasExistingValue , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Deserialize<string?> ( reader ) is not string _value ? new UserSiteUrl ( ) : new UserSiteUrl ( _value );

    public override void WriteJson( Newtonsoft.Json.JsonWriter writer , UserSiteUrl value , Newtonsoft.Json.JsonSerializer serializer ) => serializer.Serialize ( writer , value.Value );
}
