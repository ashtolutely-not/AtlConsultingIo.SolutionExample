namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct SqlPrimaryKeyColumn 
{
    public string Value { get; }
    public SqlPrimaryKeyColumn() 
    {
        Value = Default;
    }

    public SqlPrimaryKeyColumn( string value )
        => Value = !string.IsNullOrWhiteSpace( value ) ? value : Default;

    public static implicit operator string(  SqlPrimaryKeyColumn _ ) => _.Value;
    public static readonly SqlPrimaryKeyColumn Default = new( "Id" );
}

