namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct OperationContextID ( string Value )
{
    public OperationContextID() : this( Guid.NewGuid().ToString().Replace("-","") )
    {
        
    }

    public static implicit operator string( OperationContextID _ ) => _.Value;
    public static readonly OperationContextID Default = new ( new Guid().ToString().Replace("-","") );

}
