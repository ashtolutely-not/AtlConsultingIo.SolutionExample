using AtlConsultingIo.IntegrationOperations;

namespace CompanyName.Core.Integrations.Exigo;

public readonly struct ExigoEntitiesApiKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public ExigoEntitiesApiKey()
    {
        Key = "ExigoEntitiesAPI";
    }

    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );

    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( ExigoEntitiesApiKey _ ) => new( _.Key );
    public static implicit operator string( ExigoEntitiesApiKey _ ) => _.Key;

    public static readonly ExigoEntitiesApiKey Instance = new();
}
