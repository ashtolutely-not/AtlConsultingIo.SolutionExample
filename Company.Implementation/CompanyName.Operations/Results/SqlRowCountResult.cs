namespace CompanyName.Operations;

public record SqlRowCountResult( int RecordCount )
{
    public SqlRowCountResult() : this( -1 )
    {
        
    }

    public static implicit operator int( SqlRowCountResult _ )
        => _.RecordCount;
};
