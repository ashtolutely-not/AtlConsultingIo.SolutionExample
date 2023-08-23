using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AtlConsultingIo.IntegrationOperations;
internal static class SqlRowDataMapper
{
    private static readonly ConcurrentDictionary<Type,IEnumerable<PropertyInfo>> _commandTypes = new();

    public static Dictionary<string , object> ToCommandParams( object? rowData , SqlPrimaryKeyColumn idColumn )
    {
        object? _instance = rowData;

        if ( _instance is null )
            throw new ArgumentException( "Cannot create sql command, row data is null." );

        Dictionary<string,object> _params = new();
        Type type = _instance.GetType();

        bool metadataExists = _commandTypes.TryGetValue( type, out var _properties ) && _properties.Any();
        _properties = metadataExists ? _properties! : type.GetProperties().Where( x => x.GetGetMethod() is not null );

        if ( !metadataExists )
            _commandTypes.TryAdd( type , _properties );

        foreach ( var prop in _properties )
            if ( prop.GetValue( _instance ) is object _value )
                if ( !prop.Name.Equals( idColumn ) )
                    _params.Add( prop.Name , _value );

        if ( !_params.HasItems() )
            throw new ArgumentException( $"Could not resolve sql params from instance of {type.Name}" );

        return _params;
    }


}
