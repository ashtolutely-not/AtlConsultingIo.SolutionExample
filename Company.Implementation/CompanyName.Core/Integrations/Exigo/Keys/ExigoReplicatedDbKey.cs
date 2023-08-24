using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations.Exigo;

public record struct ExigoReplicatedDbKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public ExigoReplicatedDbKey( )
    {
        Key = "CompanyOnPremSqlDatabase";
    }
    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );

    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( ExigoReplicatedDbKey _ ) => new ( _.Key );
    public static implicit operator string( ExigoReplicatedDbKey _ ) => _.Key;
    public static readonly ExigoReplicatedDbKey Instance = new();
}
