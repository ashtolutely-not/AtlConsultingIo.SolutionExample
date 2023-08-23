using OneOf;
using OneOf.Types;

namespace AtlConsultingIo.IntegrationOperations;

public class TransactionOperationResult<TResult> : OneOfBase<TransactionSuccess<TResult> , OperationError>, IIntegrationOperationResult where TResult : notnull
{
    protected TransactionOperationResult( OneOf<TransactionSuccess<TResult>  , OperationError> _ ) : base( _ )
    {
    }

    public static explicit operator TransactionSuccess<TResult>?( TransactionOperationResult<TResult> _ ) => _.IsT0 ? _.AsT0 : default;
    public static explicit operator OperationError?( TransactionOperationResult<TResult> _ ) => _.IsT1 ? _.AsT1 : null;

    public static implicit operator TransactionOperationResult<TResult>( OperationError _ ) => new( _ );
    public static implicit operator TransactionOperationResult<TResult>( TransactionSuccess<TResult> _ ) => new( _ );


    public Type GetInternalType()
        => IsT0 ? AsT0.Result.GetType() : typeof(OperationError);

    public OperationResultType ResultType => Match(
            success => OperationResultType.TransactionSuccess ,
            err => OperationResultType.TransactionFailed
        );

    public JObject ResultLogValue => Match(
                success => new JObject( "Value" , new JProperty( "Result" , success.Result  )) ,
                err => err.ResultLogValue
            );
}

public readonly record struct TransactionSuccess<TResult> where TResult : notnull
{
    public readonly TResult Result;
    public TransactionSuccess( TResult result )
    {
        Result = result;
    }
}
