namespace AtlConsultingIo.IntegrationOperations;

public interface IIntegrationOperationResult
{
    OperationResultType ResultType { get; }
    JObject ResultLogValue { get; }
}
