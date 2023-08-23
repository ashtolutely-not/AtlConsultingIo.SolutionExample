using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.ApplicationInsights.Extensibility.Implementation;

namespace AtlConsultingIo.IntegrationOperations;

internal readonly record struct OperationErrorTelemetry
{
    private const string _eventName = "OperationError";
    private const string _metricName = "Errors";
    public IntegrationKey IntegrationName { get; init; }
    public OperationContextID ContextID { get; init; }
    public IntegrationType IntegrationType { get; init; }
    public string OperationType {  get; init; }
    public string ExceptionType { get; init; }  
    public Dictionary<string,string>? CustomProperties { get; init; }
    public string MetricName => IntegrationName.SafeName + _metricName;

    public static implicit operator EventTelemetry( OperationErrorTelemetry _ )
    {
        EventTelemetry item = new ( _eventName );
        item.Properties.Add( nameof( IntegrationName ) , _.IntegrationName.Value );
        item.Properties.Add( nameof( ContextID ), _.ContextID.Value );
        item.Properties.Add( nameof( IntegrationType ), _.IntegrationType.ToString() );
        item.Properties.Add( nameof( OperationType ), _.OperationType );
        item.Properties.Add( nameof( ExceptionType ), _.ExceptionType );

        if( _.CustomProperties.HasItems() )
            foreach( var( key,value ) in _.CustomProperties! )
                if( value.Trim().HasValue() )
                    item.Properties.Add( key, value );

        return item;
    }

    public OperationErrorTelemetry( OperationContext operationContext , Exception error,  Dictionary<string,string>? customProperties = null )
    {
        IntegrationName = operationContext.IntegrationName;
        ContextID = operationContext.ContextID;
        IntegrationType = operationContext.IntegrationOption.Type;
        OperationType = operationContext.OperationType;
        ExceptionType = error.GetType().Name;
        CustomProperties = customProperties;
    }


    public OperationErrorTelemetry( OperationContext operationContext, OperationError errorResult, Dictionary<string,string>? customProperties = null  )
    {
        IntegrationName = operationContext.IntegrationName;
        ContextID = operationContext.ContextID;
        IntegrationType = operationContext.IntegrationOption.Type;
        OperationType = operationContext.OperationType;
        ExceptionType = errorResult.Error.GetType().Name;
        CustomProperties = customProperties;
    }

    public OperationErrorTelemetry( OperationExceptionLog exceptionLog , IntegrationType integrationType, Dictionary<string,string>? customProperties = null )
    {
        IntegrationName = exceptionLog.IntegrationName;
        ContextID = exceptionLog.ContextID;
        OperationType = exceptionLog.OperationType;
        ExceptionType = exceptionLog.Exception.GetType().Name;
        IntegrationType = integrationType;
        CustomProperties = customProperties;
    }
}
