namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct SqlStoredProcedure( string Value ) : IResourceID
{
    public static readonly SqlStoredProcedure None = new();

    public string SafeString => Value.Replace("EXEC", "", StringComparison.OrdinalIgnoreCase ).Trim();

    public bool Equals( string? other )
    {
        return !string.IsNullOrWhiteSpace( other ) &&  Value.Equals( other , StringComparison.OrdinalIgnoreCase);
    }

    public static implicit operator string(  SqlStoredProcedure procedure )
        => procedure.SafeString;
}
