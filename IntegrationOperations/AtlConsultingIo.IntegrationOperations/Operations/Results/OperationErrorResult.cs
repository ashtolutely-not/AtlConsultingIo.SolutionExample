using OneOf.Types;

using System.Net;

namespace AtlConsultingIo.IntegrationOperations;

public readonly record struct OperationError : IIntegrationOperationResult
{
    public readonly Exception Error;
    private readonly OperationResultType _resultType;
    public OperationError( Exception err , OperationResultType resultType )
    {
        Error = err;
        _resultType = resultType;
    }

    public static readonly OperationError Default = new();
    public JObject ResultLogValue => 
        Error is null ? new JObject("Value", StringValue.NullPrintString ) : 
        new JObject( "Value", 
                new JProperty("Result", new
                {
                    ExceptionType = Error.GetType().Name,
                    ExceptionMessage = Error.Message
                })
            );

    public OperationResultType ResultType => _resultType;
}
