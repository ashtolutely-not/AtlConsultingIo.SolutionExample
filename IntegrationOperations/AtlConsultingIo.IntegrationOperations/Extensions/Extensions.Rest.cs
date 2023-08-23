


using System.Net.Http.Headers;
using System.Reflection;


namespace AtlConsultingIo.IntegrationOperations;
internal static partial class OperationExtensions
{

    public static bool Has2xxStatus( this HttpResponseMessage response )
    => ( (int) response.StatusCode ).InclusiveBetween( 200 , 299 );

    public static IntegrationKey? GetIntegrationNameOption( this HttpResponseMessage response )
    {
        if ( response.RequestMessage is not HttpRequestMessage _req )
            return null;

        return _req.Options.TryGetValue( new HttpRequestOptionsKey<IntegrationKey?>( nameof( IntegrationKey ) ) , out IntegrationKey? result )
                ? result
                : null;
    }

    public static IntegrationKey? GetIntegrationNameOption( this HttpRequestMessage request )
    {
        return request.Options.TryGetValue( new HttpRequestOptionsKey<IntegrationKey?>( nameof( IntegrationKey ) ) , out IntegrationKey? result )
                ? result
                : null;
    }

    public static bool IsFormResponse( this HttpResponseMessage response )
    {
        if ( response.Content is HttpContent _content )
            if ( _content.Headers.ContentType is MediaTypeHeaderValue _header )
                if ( _header.MediaType.EmptyIfNull().Equals( HttpContentType.Form ) )
                    return true;

        if ( response.Headers.TryGetValues( "Content-Type" , out var values ) )
            if ( values.Any( v => v.CaseInsensitiveEquals( HttpContentType.Form ) ) )
                return true;

        return false;
    }
    public static bool IsJsonResponse( this HttpResponseMessage response )
    {
        if ( response.Content is HttpContent _content )
            if ( _content.Headers.ContentType is MediaTypeHeaderValue _header )
                if ( _header.MediaType.EmptyIfNull().Equals( HttpContentType.Json ) )
                    return true;

        if ( response.Headers.TryGetValues( "Content-Type" , out var values ) )
            if ( values.Any( v => v.CaseInsensitiveEquals( HttpContentType.Json ) ) )
                return true;

        return false;
    }
    public static string GetJsonString( this JsonSerializer serializer , object content )
    {
        string json = String.Empty;

        using ( var writer = new StringWriter() )
        {
            serializer.Serialize( writer , content );
            json = writer.ToString();
        }

        return json;
    }
    public static async Task<TResult?> DeserializeJsonContent<TResult>( this HttpResponseMessage response , JsonSerializer serializer ) where TResult : class
    {
        TResult? result = null;
        if ( !response.IsJsonResponse() )
            return result;

        using ( var reader = new JsonTextReader( new StringReader( await response.Content.ReadAsStringAsync() ) ) )
        {
            result = serializer.Deserialize<TResult>( reader );
        }

        return result;
    }

}
