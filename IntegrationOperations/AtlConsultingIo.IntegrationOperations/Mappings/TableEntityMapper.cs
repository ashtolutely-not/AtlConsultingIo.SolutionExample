
using System.Collections.Concurrent;
using System.Reflection;

using Azure.Data.Tables;

namespace AtlConsultingIo.IntegrationOperations;

public static class TableEntityMapper
{

    public static object MapResult( TableEntity entity , Type resultType )
    {
        if ( Activator.CreateInstance( resultType ) is not object instance )
            throw new ArgumentException( $"Result type {resultType.Name} can not be created dynamically." );

        return MapProperties( instance , entity , resultType.GetProperties() );
    }

    public static List<TResult> MapResults<TResult>( List<TableEntity> entitites )
        where TResult : class, new()
    {
        ConcurrentBag<TResult> results = new ConcurrentBag<TResult>();
        PropertyInfo[] typeProps = typeof(TResult).GetProperties();

        Parallel.ForEach( entitites , ( entity ) =>
        {
            var instance = new TResult();
            results.Add( MapProperties( instance, entity, typeProps ));
        } );

        return results.ToList();
    }

    public static List<TResult> MapResults<TResult>( List<TableEntity> entities, Func<TableEntity,object> converter )
        where TResult : class,new()
    {
        ConcurrentBag<TResult> results = new ConcurrentBag<TResult>();
        Parallel.ForEach<TableEntity>( entities, (entity,cts) =>
        {
            object result = converter( entity );
            var typed = result as TResult;
            if( typed is null )
                throw new InvalidCastException( $"Value returned by {nameof( SearchTableDocuments )}.{nameof( SearchTableDocuments.Convert )} cannot be cast to expected return type of {( typeof( TResult ).Name )}" );

            results.Add( typed );
        } );

        return results.ToList();
    }

    static TResult MapProperties<TResult>( TResult instance , TableEntity entity , PropertyInfo[] properties )
    {
        foreach ( var prop in properties )
        {
            string? key = entity.Keys.FirstOrDefault( k => k.CaseInsensitiveEquals(prop.Name) );
            if ( !key.HasValue() )
                continue;

            object? _item = entity[key];

            if ( prop.PropertyType.IsAssignableFrom( _item.GetType() ) )
                prop.SetValue( instance , _item );
        }

        return instance;
    }
}
