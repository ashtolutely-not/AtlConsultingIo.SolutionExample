

namespace AtlConsultingIo.IntegrationOperations;

public struct AppConfigurationKey
{
    public const string WindowsDelimiter = ":";
    public const string LinuxDelimiter = "__";

    private string Key { get; set; }

    private readonly List<string> Segments;
    public readonly string Delimiter;

    public string Value => Key;
    public bool IsEmpty => string.IsNullOrWhiteSpace( Key );

    private AppConfigurationKey( AppConfigurationKey key )
    {
        Delimiter = key.Delimiter;
        Segments = key.Segments;
        Key = string.Join( Delimiter, Segments.Where( s => s.HasValue() ));
    }

    public AppConfigurationKey( string value , string delimiter )
    {
        Delimiter = delimiter.HasValue() ? delimiter : WindowsDelimiter;
        Segments = value.HasValue() ? Segments = value.Trim().Split( Delimiter ).ToList() : new();
        Key = String.Empty;
    }

    public AppConfigurationKey WithPath( string value )
    {
       if( value.HasValue() )
            Segments.Add(value.Trim());
       return this;
    }

    public AppConfigurationKey Build()
        => new( this );


    public static implicit operator string( AppConfigurationKey _ ) => _.Build().Value;
}
