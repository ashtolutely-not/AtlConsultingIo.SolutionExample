

namespace AtlConsultingIo.IntegrationOperations;
public record struct OperationStorageLog
{
    public  IntegrationKey IntegrationName { get; init; }
    public  OperationContextID ContextID { get; init; }
    public IntegrationType IntegrationType { get; init; } 
    public OperationResultType ResultType { get; init; } 
    public  string OperationType { get; init; } 
    public JObject RequestLogData { get; init; } 
    public JObject ResultLogData { get; init; } 

    public OperationStorageLog()
    {
        IntegrationName = IntegrationKey.Default;
        ContextID = OperationContextID.Default;
        IntegrationType = IntegrationType.Unknown;
        ResultType = OperationResultType.Incomplete;
        OperationType = String.Empty;
        RequestLogData = NullLogData;
        ResultLogData = NullLogData;
    }

    public static readonly JObject NullLogData = new("Value", StringValue.NullPrintString);
}
