using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public static partial class LogMessages
{
    internal static void OperationNotFound(this ILogger logger, IntegrationType integrationType, Type requestType )
    {
        _operationMissing( logger, Timestamp, integrationType.ToString(), requestType.FullName ?? requestType.Name , null);
    }
    static readonly Action<ILogger,DateTimeOffset,string,string,Exception?> _operationMissing = 
        LoggerMessage.Define<DateTimeOffset,string,string>(
                LogLevel.Critical,
                IntegrationServiceConfiguration.EventID,
                MissingTemplate
            );

    const string MissingTemplate = @"[{Timestamp}] Operation for IntegrationType of {IntegrationType} and request type of {RequestType} not found.";
    internal static void OperationError( this ILogger logger, OperationExceptionLog exceptionLog )
    {
        var action = exceptionLog.LogLevel switch
        {
            LogLevel.Trace => _exceptionTrace,
            LogLevel.Debug => _exceptionDebug,
            LogLevel.Information => _exceptionInfo,
            LogLevel.Warning => _exceptionWarning,
            LogLevel.Error => _exceptionError,
            LogLevel.Critical => _exceptionCritical,
            _ => _noOp
        };

        action( 
                logger, 
                Timestamp, 
                exceptionLog.IntegrationName, 
                exceptionLog.OperationType, 
                exceptionLog.ContextID, 
                exceptionLog.Exception.GetType().Name, 
                exceptionLog.Exception.Message , 
                exceptionLog.Exception 
            );
    }
    internal static void RequestReceivedTrace( this ILogger logger , OperationContext context, string serviceMethodName )
    {
        _operationTrace( 
                logger, 
                CallerFormat(nameof(IntegrationsService), serviceMethodName), 
                context.ContextID, 
                context.IntegrationName,
                context.OperationType,
                OperationResultType.Incomplete.ToString(),
                "Operation request received in IntegrationService...",
                null
            );
    }
    internal static void RequestCompleteTrace( this ILogger logger,  OperationContext context, string serviceMethodName , IIntegrationOperationResult result )
    {
        _operationTrace( 
                logger,  
                CallerFormat(nameof(IntegrationsService), serviceMethodName), 
                context.ContextID, 
                context.IntegrationName,
                context.OperationType,
                result.ResultType.ToString(),
                "Operation request finished processing in IntegrationService, returning result to caller...",
                null
            );
    }

    internal static void OperationStartTrace( this ILogger logger , IntegrationKey name , OperationContextID contextID , Type handlerType )
    {
         _operationTrace( 
                logger, 
                CallerFormat(handlerType.Name, "Execute()"), 
                contextID, 
                name,
                handlerType.Name,
                StringValue.NullPrintString,
                $"Operation executing...",
                null
            );
    }
    internal static void OperationEndTrace( this ILogger logger , IntegrationKey name , OperationContextID contextID , Type handlerType )
    {
         _operationTrace( 
                logger, 
                CallerFormat( handlerType.Name, "Execute()" ), 
                contextID, 
                name,
                handlerType.Name,
                StringValue.NullPrintString,
                $"IRequestHandler ran to completion, returning result to service...",
                null
            );
    }


    const string OperationTraceTemplate = 
        @"
                Caller: {CallerInfo}
                ContextID: {ContextID}
                IntegrationName: {IntegrationName} 
                RequestType: {RequestType}
                ResultType: {ResultType}
                Message: {Message}
        ";

    static readonly Action<ILogger, string, OperationContextID, IntegrationKey, string, string, string, Exception?> _operationTrace
        = LoggerMessage.Define<string,OperationContextID,IntegrationKey, string , string, string>(LogLevel.Trace, IntegrationServiceConfiguration.EventID, OperationTraceTemplate);
    static DateTimeOffset Timestamp => DateTimeOffset.UtcNow;
    static string CallerFormat( string typeName, string methodName) 
        => $"{typeName}.{methodName}()";


    #region Operation Exception

    const string OperationExceptionTemplate = 
        @"
        ---------------------------------------------------------------------------------------------
            ErrorDate: {Timestamp}
            IntegrationName: 
                {IntegrationName}
            OperationRequestType: {RequestType}
            OperationContextID: 
                {ContextID}
            ExceptionType: {ExceptionType}
            Message: {ErrorMessage}
        ---------------------------------------------------------------------------------------------
        ";


    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _exceptionTrace 
        = LoggerMessage.Define<DateTimeOffset,IntegrationKey,string,OperationContextID,string,string>( LogLevel.Trace, IntegrationServiceConfiguration.EventID, OperationExceptionTemplate );
    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _exceptionDebug 
        = LoggerMessage.Define<DateTimeOffset,IntegrationKey,string,OperationContextID,string,string>( LogLevel.Debug, IntegrationServiceConfiguration.EventID, OperationExceptionTemplate );    
    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _exceptionInfo 
        = LoggerMessage.Define<DateTimeOffset,IntegrationKey,string,OperationContextID,string,string>( LogLevel.Information, IntegrationServiceConfiguration.EventID, OperationExceptionTemplate );    
    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _exceptionWarning 
        = LoggerMessage.Define<DateTimeOffset,IntegrationKey,string,OperationContextID,string,string>( LogLevel.Warning, IntegrationServiceConfiguration.EventID, OperationExceptionTemplate );    
    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _exceptionError 
        = LoggerMessage.Define<DateTimeOffset,IntegrationKey,string,OperationContextID,string,string>( LogLevel.Error, IntegrationServiceConfiguration.EventID, OperationExceptionTemplate );
    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _exceptionCritical 
        = LoggerMessage.Define<DateTimeOffset,IntegrationKey,string,OperationContextID,string,string>( LogLevel.Critical, IntegrationServiceConfiguration.EventID, OperationExceptionTemplate );

    static readonly Action<ILogger,DateTimeOffset,IntegrationKey,string,OperationContextID,string,string,Exception> _noOp 
        = ( logger,dt, name, type, context, errTy, msg , ex) => { };

    #endregion

    #region Operation Debug

    const string OperationDebugTemplate = 
    @"
    ---------------------------------------------------------------------------------------------
        OperationDate: {Timestamp} 
        {Line1}
        {Line2}
            
        RequestJSON:
        {FormattedJson}
                
        ResultType: {LogType}
    ---------------------------------------------------------------------------------------------
    ";

    static readonly Action<ILogger, DateTimeOffset, string, string, string,string,Exception? > _operationDebug
        = LoggerMessage.Define<DateTimeOffset, string, string, string,string>( LogLevel.Debug, IntegrationServiceConfiguration.EventID, OperationDebugTemplate );

    #endregion



}
