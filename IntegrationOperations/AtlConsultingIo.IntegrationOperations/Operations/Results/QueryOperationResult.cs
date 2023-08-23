

using OneOf;
namespace AtlConsultingIo.IntegrationOperations;

public partial class QueryOperationResult<TResult> : OneOfBase<QuerySuccess<TResult>, OperationError>, IIntegrationOperationResult
    where TResult : class, new()
{
    protected QueryOperationResult( OneOf<QuerySuccess<TResult> , OperationError> _ ) : base( _ )
    {
    }

    public Type GetInternalType()
        => IsT0 ? typeof( QueryOperationResult<> ) : typeof( OperationError );


    public static implicit operator QueryOperationResult<TResult>( QuerySuccess<TResult> _ ) => new( _ );
    public static implicit operator QueryOperationResult<TResult>( OperationError _ ) => new( _ );
    public static implicit operator QueryOperationResult<TResult>( NotFoundResult _ ) => new( OneOf<QuerySuccess<TResult>, OperationError>.FromT0(_));
    public static implicit operator QueryOperationResult<TResult>( TResult _ ) => new( OneOf<QuerySuccess<TResult>, OperationError>.FromT0(_));
    public static implicit operator QueryOperationResult<TResult>( List<TResult> _ ) => new( OneOf<QuerySuccess<TResult>, OperationError>.FromT0(_));

    public static explicit operator bool( QueryOperationResult<TResult> _ ) => _.IsT0;

    public bool IsErrorResult => IsT1;
    public bool IsNotFoundResult => IsT0 && AsT0.IsT2;
    public bool IsSingleResult => IsT0 && AsT0.IsT0;
    public bool IsListResult => IsT0 && AsT0.IsT1;

    public string? ErrorMessageOrDefault => IsT1 ? AsT1.Error.Message : null;
    public TResult? GetSingleOrFirstListItemResult()
    {
        if( TryPickT0(out var success,out var err))
            if( success.TryPickT0( out var item, out _ ))
                return item;
            else if( success.TryPickT1( out var items, out _ ))
                return items.FirstOrDefault();
        return null;
    }

    public TResult? GetSingleResult()
    {
        if( TryPickT0(out var success,out var err))
            if( success.TryPickT0( out var item, out _ ))
                return item;
        return null;
    }
    public List<TResult>? GetListResult()
    {
        if( TryPickT0(out var success,out _ ))
            if( success.TryPickT1( out var items, out _ ))
                return items;

        return null;

    }
    public OperationResultType ResultType => Match(
            success => OperationResultType.QuerySuccess,
            err => OperationResultType.QueryFailed
        );

    public JObject ResultLogValue => Match(
            success => success.OperationLogResultValue,
            err => err.ResultLogValue
        );
}

public class QuerySuccess<TResult> : OneOfBase<TResult , List<TResult> , NotFoundResult>
    where TResult : class,new()
{
    public QuerySuccess( OneOf<TResult , List<TResult> , NotFoundResult> _ ) : base( _ )
    {

    }


    public static implicit operator QuerySuccess<TResult>( List<TResult> _ ) => new( _ );
    public static implicit operator QuerySuccess<TResult>( TResult _ ) => new( _ );
    public static implicit operator QuerySuccess<TResult>( NotFoundResult _ ) => new( _ );

    public JObject OperationLogResultValue => Match<JObject>(
                single => new JObject( "Value" , new JProperty( "Result" , new { Data = single } ) ) ,
                multi => new JObject( "Value" , new JProperty( "Result" , new { ResultCount = multi.Count } ) ) ,
                nf => new JObject( "Value" , new JProperty( "Result" , new { NotFound = String.Empty } ) )
            );

}

public readonly record struct NotFoundResult
{
    public static readonly NotFoundResult Instance = new ();

}
