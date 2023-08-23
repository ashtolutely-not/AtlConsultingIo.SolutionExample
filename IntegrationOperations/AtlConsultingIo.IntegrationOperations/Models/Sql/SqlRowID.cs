using Newtonsoft.Json.Linq;

namespace AtlConsultingIo.IntegrationOperations;


public  record  SqlRowID
{
    public StringOrInteger Id { get; }

    private SqlRowID()
    {
        Id = new(0);
    }

    public SqlRowID( int id )
    {
        Id = new(id.GreatestValue(0));
    }

    public SqlRowID( string value )
    {
        Id = new( value );
    }

    internal SqlCommandText SqlString
        => new SqlCommandText( Id.Value.Match(
                 str => str.WithSingleQuotes(),
                 num => num.ToString()
                ));

    public static readonly SqlRowID Default = new();
}
