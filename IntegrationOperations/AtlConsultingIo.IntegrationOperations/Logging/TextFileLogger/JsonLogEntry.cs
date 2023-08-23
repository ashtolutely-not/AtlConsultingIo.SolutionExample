
namespace AtlConsultingIo.IntegrationOperations;

public struct JsonLogEntry<TState>
{
    public DateTimeOffset Timestamp { get; set; }
    public string LogLevel { get; set; }
    public int EventId { get; set; }
    public string? EventName { get; set; }
    public string Category { get; set; }
    public Exception? Exception { get; set; }
    public TState? State { get; set; }


    public JsonLogEntry()
    {
        Timestamp = DateTimeOffset.UtcNow;
        LogLevel = string.Empty;
        EventId = 0;
        Category = string.Empty;
        EventName = null;
        Exception = null;
        State = default;
    }
}
