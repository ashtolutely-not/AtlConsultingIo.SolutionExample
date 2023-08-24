using CompanyName.Core.Entities.Order;

using Newtonsoft.Json.Linq;


namespace CompanyName.Core.Entities.User;
public class PointTransactionConverter : JsonConverter
{
    public override bool CanConvert( Type objectType )
    {
        return objectType.IsAssignableTo ( typeof ( IOrderPointTransaction ) );
    }

    public override void WriteJson( JsonWriter writer , object? value , JsonSerializer serializer )
    {
        if ( value == null )
        {
            writer.WriteNull ( );
            return;
        }

        JObject jobject = JObject.FromObject(value);
        jobject.AddFirst ( new JProperty ( "$type" , value.GetType ( ).AssemblyQualifiedName ) );

        jobject.WriteTo ( writer );
    }

    public override object? ReadJson( JsonReader reader , Type objectType , object? existingValue , JsonSerializer serializer )
    {
        if ( reader.TokenType == JsonToken.Null )
        {
            return null;
        }

        JObject jobject = JObject.Load(reader);
        string typeName = jobject.Property("$type")?.Value<string>() ?? String.Empty;
        Type? concreteType = Type.GetType(typeName);

        if ( concreteType == null || !objectType.IsAssignableFrom ( concreteType ) )
        {
            return null;
        }

        return jobject.ToObject ( concreteType , serializer );
    }
}
