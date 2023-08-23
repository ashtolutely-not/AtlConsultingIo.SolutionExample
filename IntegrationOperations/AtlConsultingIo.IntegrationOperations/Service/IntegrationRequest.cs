namespace AtlConsultingIo.IntegrationOperations;

public abstract record IntegrationRequest<TOperationRequest> where TOperationRequest : class
{
    public OperationContextID ContextID { get; protected init; }
    public IntegrationKey Key { get; protected init; }
    protected TOperationRequest OperationRequest { private get; init; } = null!;


    public static implicit operator OperationStorageLog( IntegrationRequest<TOperationRequest> _ )
        => new OperationStorageLog
        {
            IntegrationName = _.Key,
            ContextID = _.ContextID,
            OperationType = _.OperationRequest is null ? StringValue.NullPrintString : _.OperationRequest.GetType().Name,
            RequestLogData = _.OperationRequest is null ? OperationStorageLog.NullLogData : new JObject("Value", _.OperationRequest)
        };

    public static implicit operator OperationContext( IntegrationRequest<TOperationRequest> _ )
        => new OperationContext
        (
             _.Key,
             _.ContextID,
             IntegrationOption.Default,
            _.GetType().Name
         );
}
