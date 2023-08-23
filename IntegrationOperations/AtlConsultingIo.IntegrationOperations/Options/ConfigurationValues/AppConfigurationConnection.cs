

namespace AtlConsultingIo.IntegrationOperations;

public struct AppConfigurationConnection
{
    public string Value { get; set; }

    public AppConfigurationConnection( string value )
        => Value = value.EmptyIfNull();

    public bool IsEmpty => !Value.HasValue();
    public static implicit operator string( AppConfigurationConnection _ )
        => _.Value;
}
