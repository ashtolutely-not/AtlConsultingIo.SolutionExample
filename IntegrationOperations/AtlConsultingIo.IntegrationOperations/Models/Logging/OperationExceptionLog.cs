using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

internal readonly record struct OperationExceptionLog (
        Exception Exception, 
        LogLevel LogLevel, 
        IntegrationKey IntegrationName,
        OperationContextID ContextID, 
        string OperationType
    );
