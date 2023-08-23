using System.Reflection;
namespace AtlConsultingIo.IntegrationOperations;

public struct LogValues<T> where T : notnull
{
    public Dictionary<string,object> Value { get; }
    public LogValues( T value )
    {
        Value = new Dictionary<string, object>();
        if ( value is null )
            return;

        Type type = value.GetType();
        PropertyInfo[] properties = type.GetProperties();

        foreach ( PropertyInfo property in properties )
        {
            string propertyName = property.Name; 
            object? propertyValue = property.GetValue(value);
            Value.Add( propertyName , propertyValue ?? StringValue.NullPrintString );
        }
    }

    public static implicit operator Dictionary<string,object>( LogValues<T> _ )
        => _.Value;
}


