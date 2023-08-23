

namespace AtlConsultingIo.IntegrationOperations;

public struct StorageAccountConnection
{
    public string Value { get; set; }
    public StorageAccountConnection()
        => Value = String.Empty;
    public StorageAccountConnection( string value )
        => Value = value.EmptyIfNull();
    public bool IsEmpty => !Value.HasValue();
    public static implicit operator string( StorageAccountConnection _ )
        => _.Value;
}
