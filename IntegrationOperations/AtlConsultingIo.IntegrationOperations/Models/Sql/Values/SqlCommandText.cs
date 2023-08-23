namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct SqlCommandText( string Value )
{
    public static readonly SqlCommandText None = new();

    public SqlCommandText( StringBuilder commandBuilder )
        : this( commandBuilder.ToString() )
    {
        
    }

    public static implicit operator string( SqlCommandText _ )
        => _.Value;
};
