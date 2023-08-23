

namespace AtlConsultingIo.IntegrationOperations;

public record IntegrationServiceLogSetting
{
    private static readonly Options _default = new();
    public bool StorageLoggingEnabled { get; set; }
    public bool DebugLoggingEnabled { get; set; }
    public Options? Value { get; set; }

    public record Options
    {
        public StorageAccountConnection StorageLogConnection { get; set; }
        public bool UseBlobStorage { get; set; }
        public bool UseDocumentStorage { get; set; }
        public string? StorageLogResourceName { get; set; }
    }

    public Options GetValueOrDefault( ) => Value ?? _default;

    public static readonly IntegrationServiceLogSetting Default = new();

}
