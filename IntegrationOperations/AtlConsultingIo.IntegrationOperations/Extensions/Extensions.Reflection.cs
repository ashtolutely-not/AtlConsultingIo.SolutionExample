using FluentValidation;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;

using System.Reflection;

namespace AtlConsultingIo.IntegrationOperations;
internal static partial class OperationExtensions
{

    public static void TrySet<T>( this PropertyInfo property , T instance , object? value )
        where T : notnull
    {
        try { property.SetValue( instance , value ); }
        catch ( Exception ) { }
    }

    internal static List<JsonConverter>? InitializeJsonConverters( this Assembly assembly )
    {
        if ( assembly == null )
            return null;

        var types = assembly.FindJsonConverterTypes();
        if ( !types.HasItems() ) return null;

        var list = types!
            .Select( t => t.InitializeJsonConverter()  )
            .ToList()
            .Where( c => c is not null )
            .Select( c => c!);

        return list.Any() ? list.ToList() : null;
    }
    internal static List<Type>? FindJsonConverterTypes( this Assembly assembly )
    {
        List<Type> types = new();
        var converterTypes = assembly.GetTypes()
                .Where(type => typeof(JsonConverter).IsAssignableFrom(type) && !type.IsAbstract && !type.IsGenericTypeDefinition);
        if ( converterTypes.HasItems() )
            types.AddRange( converterTypes.ToList() );

        var genericConverterTypes
                = assembly.GetTypes()
                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                        && type.BaseType.GetGenericTypeDefinition() == typeof(JsonConverter<>));
        if ( genericConverterTypes.HasItems() )
            types.AddRange( genericConverterTypes.ToList() );

        return types.Any() ? types : null;
    }
    internal static JsonConverter? InitializeJsonConverter( this Type converterType )
    {
        try
        {
            if ( converterType.BaseType is not null && converterType.BaseType.IsGenericType )
            {
                var genericType = converterType.BaseType.GetGenericArguments()[0];
                var converterInstance = Activator.CreateInstance(converterType) as JsonConverter;
                if ( converterInstance is null )
                    return null;

                return (JsonConverter?) typeof( JsonConverter<> )
                    .MakeGenericType( genericType )
                    .GetConstructor( Type.EmptyTypes )?
                    .Invoke( null );
            }
            else
                return Activator.CreateInstance( converterType ) as JsonConverter;
        }
        catch ( Exception ) { return null; }
    }

}
