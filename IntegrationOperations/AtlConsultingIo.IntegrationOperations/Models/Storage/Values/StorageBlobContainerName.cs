using System.Collections.Immutable;

namespace AtlConsultingIo.IntegrationOperations;

public  record struct StorageBlobContainerName : IResourceID, IEquatable<string>
{
    public string Value { get; init; } = String.Empty;
    public bool IsEmpty => String.IsNullOrWhiteSpace( Value );
    public bool IsRoot => Value.Equals( "$root" );
    public ImmutableList<string> PathSegments { get; private init; }
    public StorageBlobContainerName( string name ) => (Value, PathSegments) = ( name, name.Split( '/' ).ToImmutableList()); 

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Equals( Value );

    public static implicit operator string(  StorageBlobContainerName _ ) => _.Value;    
}
