

namespace AtlConsultingIo.IntegrationOperations;

public struct AppInsightsConnection
{
    public string Value { get; set; }
    public AppInsightsConnection( string value )
        => Value = value.EmptyIfNull();

    public AppInsightsConnection()
    {
        Value = String.Empty;
    }
    public bool IsEmpty => !Value.HasValue();
    public static implicit operator string( AppInsightsConnection _ )
        => _.Value;
}
