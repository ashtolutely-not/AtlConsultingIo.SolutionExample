using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations.KountApi;

public struct KountApiKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public KountApiKey( )
    {
        Key = "KountAPI";
    }

    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );
    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( KountApiKey _ ) => new ( _.Key );
    public static implicit operator string( KountApiKey _ ) => _.Key;
    public static readonly KountApiKey Instance = new();
}
