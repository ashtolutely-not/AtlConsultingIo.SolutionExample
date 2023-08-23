

using System.Collections.Immutable;

namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct StorageBlobName : IResourceID, IEquatable<string>
{
    public string Value { get; private init;}
    public bool IsEmpty => String.IsNullOrWhiteSpace( Value );  
    public ImmutableList<string> PathSegments { get; private init; }

    public StorageBlobName( string name )
        => (Value, PathSegments) = ( name, name.Split( '/' ).ToImmutableList());

    private StorageBlobName( StorageBlobName blobName , string pathValue )
    {
        if( !pathValue.HasValue() )
        {
            Value = blobName.Value;
            PathSegments = blobName.PathSegments;
            return;
        }

        List<string> segments = blobName.PathSegments.ToList();
        string[] parts = pathValue.Split('/');
        if( parts.Length > 1 )
            segments.AddRange( parts  );
        else segments.Add(pathValue);

        Value = string.Join('/', segments);
        PathSegments = segments.ToImmutableList();
    }
    private StorageBlobName( StorageBlobName blobName, StorageBlobContainerName containerName )
    {
        if( containerName.IsEmpty )
        {
            Value = blobName.Value;
            PathSegments = blobName.PathSegments;
            return;
        }

        List<string> segments = containerName.PathSegments.ToList();
        segments.AddRange( blobName.PathSegments );

        PathSegments = segments.ToImmutableList();
        Value = string.Join("/", segments);
    }
    public StorageBlobName WithPathValue( string value )
        => new StorageBlobName( this, value );
    public StorageBlobName WithContainerPath( StorageBlobContainerName containerName ) 
        => new StorageBlobName( this, containerName );

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Equals( Value );
    
    public static implicit operator string( StorageBlobName _ ) => _.Value;

    public StorageBlobName WithJsonFileExtension()
    {
        string lastSegement = PathSegments[ PathSegments.Count - 1];
        int extIndex = lastSegement.LastIndexOf('.');

        if(  extIndex < 0 ) 
            return new StorageBlobName( Value + ".json");

        string fileExt = Value.Substring(extIndex);
        return new StorageBlobName( Value.Replace(fileExt, ".json") );
    }

}


