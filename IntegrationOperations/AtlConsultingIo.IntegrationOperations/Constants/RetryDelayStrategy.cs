namespace AtlConsultingIo.IntegrationOperations;

public enum RetryDelayStrategy
{
    Jitter,
    JitterV2,
    Constant,
    Exponential,
    Linear
}
