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
namespace CompanyName.Core.Integrations.SendGridApi;
public class EmailListConverter : JsonConverter<IEnumerable<SGEmailAddress>>
{
    public override IEnumerable<SGEmailAddress>? ReadJson( JsonReader reader , Type objectType , IEnumerable<SGEmailAddress>? existingValue , bool hasExistingValue , JsonSerializer serializer )
    {
        if ( reader.TokenType != JsonToken.StartArray )
            return null;

        return serializer.Deserialize<List<SGEmailAddress>>(reader);

    }

    public override void WriteJson( JsonWriter writer , IEnumerable<SGEmailAddress>? value , JsonSerializer serializer )
    {
        if ( value == null )
        {
            writer.WriteNull();
            return;
        }

        // Use a HashSet to store unique email addresses
        var uniqueEmailAddresses = new HashSet<string>();

        writer.WriteStartArray();

        // Iterate through the input collection and add unique email addresses to the HashSet
        foreach ( var email in value )
        {
            if ( !uniqueEmailAddresses.Contains( email.Email ) )
            {
                // Write the unique email address to the JSON writer
                writer.WriteValue( email.Email );

                // Add the email address to the HashSet to keep track of uniqueness
                uniqueEmailAddresses.Add( email.Email );
            }
        }

        writer.WriteEndArray();
    }
}
