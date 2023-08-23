namespace AtlConsultingIo.IntegrationOperations;

public record struct SqlTableName : IResourceID, IEquatable<string>
{
    public string Value { get; init; }
    public bool IsEmpty => string.IsNullOrWhiteSpace(Value);

    public SqlTableName( string name )
        => Value = name;

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Equals( Value , StringComparison.OrdinalIgnoreCase );

    
    public static implicit operator string( SqlTableName _ ) => _.Value;
    public static readonly SqlTableName Default = new();
}
