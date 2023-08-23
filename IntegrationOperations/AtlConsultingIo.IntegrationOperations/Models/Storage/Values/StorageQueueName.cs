namespace AtlConsultingIo.IntegrationOperations;

public record struct StorageQueueName : IResourceID, IEquatable<string>
{
    public string Value { get; init; }
    public bool IsEmpty => string.IsNullOrWhiteSpace( Value );  

    public StorageQueueName( string name )
    {
        Value = name;
    }

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Equals( Value );

    public static implicit operator string(  StorageQueueName _ ) => _.Value;
    public static readonly StorageQueueName Default = new();
}
