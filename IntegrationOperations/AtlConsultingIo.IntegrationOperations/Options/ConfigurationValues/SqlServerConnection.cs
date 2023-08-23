

namespace AtlConsultingIo.IntegrationOperations;

public struct SqlServerConnection
{
    public string Value { get; set; }
    public bool IsEmpty => !Value.HasValue();

    public SqlServerConnection( string value )
        => Value = value.EmptyIfNull();
    public SqlServerConnection()
    {
        Value = String.Empty;
    }
    public static implicit operator string( SqlServerConnection _ )
        => _.Value;
}
