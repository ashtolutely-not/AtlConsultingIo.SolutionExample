
using System.Text.RegularExpressions;

using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;


internal static partial class OperationExtensions
{
    private const string _singleQuote = "'";
    public static bool InclusiveBetween( this int val , int min , int max )
        => val >= min && val <= max;

    public static int GreatestValue( this int value , int other )
        => value >= other ? value : other;

    public static bool HasValue( this string? value )
         => !string.IsNullOrWhiteSpace( value );

    public static bool CaseInsensitiveEquals( this string value , string value2 )
        => value.Equals( value2 , StringComparison.OrdinalIgnoreCase );
    public static string EmptyIfNull( this string? value )
        => value ?? String.Empty;

    public static string WithSingleQuotes( this string value )
        => String.Concat( _singleQuote , value , _singleQuote );

    public static string AlphaNumericCharactersOnly( this string value )
        => Regex.Replace( value , "[^a-zA-Z0-9]+" , "" , RegexOptions.Compiled );
    public static string AlphanumericAndUnderscoreOnly( this string value )
        => Regex.Replace( value , "[^a-zA-Z0-9_]+" , "" , RegexOptions.Compiled );

    public static string ReplaceWhitespaceWithUnderscore( this string txt )
        => txt.Replace( " " , "_" );

    public static string ToFormattedJsonString<T>( this T value ) where T : notnull
        => JsonConvert.SerializeObject( value , Formatting.Indented );

    public static bool HasItems<T>( this IEnumerable<T>? collection )
        => collection is not null && collection.Any();

    public static T Copy<T>( this T source , T target ) where T : notnull
    {
        var props = source.GetType().GetProperties();
        foreach ( var prop in props )
            prop.TrySet( target , prop.GetValue( source , null ) );

        return target;
    }

    public static bool None( this LogLevel level )
        => level.Equals( LogLevel.None );

    public static string FormattedMessage( this Exception exception , IntegrationKey integrationName )
    {
        var prefix = string.Join('_' , integrationName.LogString() , "ERROR");
        return string.IsNullOrWhiteSpace( exception.Message ) ?
                prefix : string.Join( " : " , exception.Message );
    }
    public static string LogString( this IntegrationKey name )
    {
        string _value = name.Value.AlphaNumericCharactersOnly();
        string formatted = char.ToUpper(_value[0]).ToString();

        for ( int i = 1; i < _value.Length; i++ )
            formatted += char.IsUpper( _value[ i ] ) ? "_" + _value[ i ] : char.ToUpper( _value[ i ] );

        return formatted;
    }
    public static bool StorageLoggingEnabled( this OperationStorageLog operationLog , IntegrationOption integrationOption )
        => integrationOption.LoggingOption.GetOptionOrDefault().StorageLogResultTypes.Any( t => t.Equals( operationLog.ResultType ) );


}
