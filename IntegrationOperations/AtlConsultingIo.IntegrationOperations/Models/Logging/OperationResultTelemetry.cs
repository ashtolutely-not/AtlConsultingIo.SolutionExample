namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct OperationResultTelemetry(IntegrationKey IntegrationName, OperationResultType ResultType, string OperationType )
{
    public string MetricName => IntegrationName.SafeName + "Executions";

    public static implicit operator OperationResultTelemetry( OperationStorageLog _ )
        => new( _.IntegrationName, _.ResultType, _.OperationType );
}
