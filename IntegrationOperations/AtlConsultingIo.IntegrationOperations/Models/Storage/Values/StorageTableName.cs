namespace AtlConsultingIo.IntegrationOperations;

public record struct StorageTableName : IResourceID, IEquatable<string>
{
    public string Value { get; init; } = String.Empty;
    public bool IsEmpty => string.IsNullOrWhiteSpace( Value );

    public StorageTableName( string name ) => Value =  name ;  

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Equals( Value );

    public static implicit operator string(  StorageTableName _ ) => _.Value;
}
