
using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public class OperationErrorException : Exception
{
    public string OperationID { get; set; }
    public string IntegrationName { get; set; }
    public string IntegrationType { get; set; }
    public string RequestType { get; set; }
    public string ResultType { get; set; }

    internal OperationStorageLog OperationLog { get; init; }
    internal LogLevel ExceptionLogLevel { get; init; } = LogLevel.None;

    internal OperationErrorException( IntegrationOption integration, OperationStorageLog operationLog , Exception innerException )
        : base( innerException.FormattedMessage( operationLog.IntegrationName ), innerException )
    {
        ExceptionLogLevel = integration.LoggingOption?.Value?.ExceptionLogLevel ?? LogLevel.Warning;

        OperationLog = operationLog;

        OperationID = OperationLog.ContextID;
        IntegrationName = OperationLog.IntegrationName;
        IntegrationType = OperationLog.IntegrationType.ToString();
        RequestType = OperationLog.OperationType;
        ResultType = OperationLog.ResultType.ToString();
    }


}
