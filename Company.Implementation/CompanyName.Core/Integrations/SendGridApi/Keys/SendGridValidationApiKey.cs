using AtlConsultingIo.IntegrationOperations;
namespace CompanyName.Core.Integrations.SendGridApi;
public struct SendGridValidationApiKey : IEquatable<IntegrationKey>, IEquatable<string>
{
    private readonly string Key;

    public SendGridValidationApiKey( )
    {
        Key = "SendGridValidationAPI";
    }

    public bool Equals( string? other ) => !string.IsNullOrEmpty ( other ) && Key.ToLower ( ).Equals ( other.ToLower ( ) );

    public bool Equals( IntegrationKey other ) => !string.IsNullOrEmpty ( other.Value ) && Key.ToLower ( ).Equals ( other.Value.ToLower ( ) );

    public static implicit operator IntegrationKey( SendGridValidationApiKey _ ) => new( _.Key );
    public static implicit operator string( SendGridValidationApiKey _ ) => _.Key;
    public static readonly SendGridValidationApiKey Instance = new();
}
