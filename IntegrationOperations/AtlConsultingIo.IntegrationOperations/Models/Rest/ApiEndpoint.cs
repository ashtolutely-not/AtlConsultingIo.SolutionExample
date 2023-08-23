namespace AtlConsultingIo.IntegrationOperations;

public struct ApiEndpoint : IResourceID, IEquatable<string>
{
        public string Value { get; init; }
    public bool IsEmpty => string.IsNullOrWhiteSpace(Value);

    public ApiEndpoint( string name )
        => Value = name;

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Equals( Value , StringComparison.OrdinalIgnoreCase );

    
    public static implicit operator string( ApiEndpoint _ ) => _.Value;
    public static implicit operator Url( ApiEndpoint _ ) => new (_.Value);
    public static explicit operator Uri?( ApiEndpoint _ ) => !_.Value.HasValue() ? null : new Uri( _.Value, UriKind.Relative);
}
