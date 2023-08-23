using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;

namespace AtlConsultingIo.IntegrationOperations;

public static class FormResponseMapper
{
    private static ConcurrentDictionary<Type,IEnumerable<PropertyInfo>> _formTypes = new();
    public static async Task<object> ToResultTypeAsync( HttpResponseMessage response , Type resultType )
    {
        if ( !response.Has2xxStatus() )
            throw new HttpRequestException( "Http Response status indicates error. Cannot convert form result to type instance." );

        if ( !response.IsFormResponse() )
            throw new InvalidOperationException( "Http Response headers indicates response does not include form content" );

        object? instance = Activator.CreateInstance( resultType );
        if ( instance is null )
            throw new InvalidOperationException( $"Cannot dynamically create instance of {resultType.Name}, check to ensure a public parameterless constructor exists." );

        NameValueCollection responseData = HttpUtility.ParseQueryString( await response.Content.ReadAsStringAsync() );
        if ( !responseData.HasKeys() )
            return instance;

        bool metadataExists = _formTypes.TryGetValue( resultType, out IEnumerable<PropertyInfo>? _props );
        IEnumerable<PropertyInfo> formProps = metadataExists ? _props! : resultType.GetProperties().Where( IsFormProperty );

        if ( !metadataExists )
            _formTypes.TryAdd( resultType , formProps );

        foreach ( var prop in formProps )
        {
            string formField = prop.GetCustomAttribute<FormFieldAttribute>() is FormFieldAttribute _attr ? _attr.Name : prop.Name;
            string? formValue = responseData.Get(formField);

            if ( formValue.HasValue() )
                try { prop.SetValue( formValue , instance ); }
                catch { }
        }

        return instance;
    }

    public static FormUrlEncodedContent? ToUrlEncodedForm( this object? requestData )
    {
        object? _instance = requestData;

        if ( _instance is null )
            return default;

        Type dataType = _instance.GetType();

        bool metadataExists = _formTypes.TryGetValue( dataType, out IEnumerable<PropertyInfo>? _props );
        IEnumerable<PropertyInfo> formProps = metadataExists ? _props! : dataType.GetProperties().Where( IsFormProperty );

        if ( !formProps.HasItems() ) return null;
        if ( !metadataExists )
            _formTypes.TryAdd( dataType , formProps );

        Dictionary<string,string> formValues = new();
        foreach ( var p in formProps )
        {
            if ( p.GetValue( _instance ) is not object _value )
                continue;

            string? strValue = _value.ToString();
            if ( string.IsNullOrWhiteSpace( strValue ) )
                continue;

            string name = p.GetCustomAttribute<FormFieldAttribute>() is FormFieldAttribute _attr ? _attr.Name : p.Name;
            formValues[ name ] = strValue;
        }

        return formValues.HasItems() ? new FormUrlEncodedContent( formValues ) : null;
    }
    private static bool IsFormProperty( this PropertyInfo property )
         => property.GetCustomAttribute<FormIgnoreAttribute>() is null
             && ( property.PropertyType.Equals( typeof( string ) ) || property.PropertyType.IsValueType )
             && ( property.CanRead || property.GetCustomAttribute<FormFieldAttribute>() != null );

}
