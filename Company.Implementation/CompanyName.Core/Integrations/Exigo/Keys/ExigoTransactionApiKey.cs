using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations.Exigo;

public readonly struct ExigoTransactionApiKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;
    public ExigoTransactionApiKey()
    {
        Key = "ExigoTransactionAPI";
    }
    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );
    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( ExigoTransactionApiKey _ ) => new( _.Key );
    public static implicit operator string( ExigoTransactionApiKey _ ) => _.Key;

    public static readonly ExigoEntitiesApiKey Instance = new();
}
