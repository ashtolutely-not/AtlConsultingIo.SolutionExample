namespace AtlConsultingIo.IntegrationOperations;

public record IntegrationOption
{
    public bool Enabled { get; set; }     
    public IntegrationKey Name { get; set; } 
    [JsonConverter(typeof(StringEnumConverter))]
    public IntegrationType Type { get; set; }
    public OperationRetrySetting RetryOption { get; set; } = OperationRetrySetting.Default;
    public OperationLogSetting LoggingOption { get; set; } = OperationLogSetting.Default;

    

    public static readonly IntegrationOption Default = new();

    public const string ClientConfigurationBindingKey = "ClientConfiguration";
    internal IntegratedClientSettings ClientConfiguration { get; set; } = null!;

}
