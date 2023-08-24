using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations;

public readonly struct AppStorageKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public AppStorageKey()
    {
        Key = "TotalLifeAppStorage";
    }

    public AppStorageKey( string value ) => Key = value;
    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );
    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( AppStorageKey _ ) => new( _.Key );
    public static implicit operator string( AppStorageKey _ ) => _.Key;

    public static readonly AppStorageKey Instance = new();
}
