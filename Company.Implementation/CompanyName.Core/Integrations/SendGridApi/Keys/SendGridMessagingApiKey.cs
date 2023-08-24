using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations.SendGridApi;

public struct SendGridMessagingApiKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public SendGridMessagingApiKey( )
    {
        Key = "SendGridMessagingAPI";
    }

    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );
    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( SendGridMessagingApiKey _ ) => new ( _.Key );
    public static implicit operator string( SendGridMessagingApiKey _ ) => _.Key;
    public static readonly SendGridMessagingApiKey Instance = new();
}
