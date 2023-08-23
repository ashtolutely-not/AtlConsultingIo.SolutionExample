using OneOf;

namespace AtlConsultingIo.IntegrationOperations;

public class CommandOperationResult : OneOfBase<CommandSuccess , OperationError>, IIntegrationOperationResult
{
    protected CommandOperationResult( OneOf<CommandSuccess , OperationError> _ ) : base( _ )
    {
    }

    public Type GetInternalType()
        => IsT0 ? typeof( CommandSuccess ) : typeof( OperationError );

    public static implicit operator CommandOperationResult( CommandSuccess _ ) => new ( _ );
    public static implicit operator CommandOperationResult( OperationError _ ) => new ( _ );

    public static explicit operator CommandSuccess( CommandOperationResult _ ) => _.AsT0;
    public static explicit operator OperationError( CommandOperationResult _ ) => _.AsT1;

    public static explicit operator bool( CommandOperationResult _ ) => _.IsT0;

    public OperationResultType ResultType => Match(
                success => OperationResultType.CommandSuccess,
                err => OperationResultType.CommandFailed
            );

    public JObject ResultLogValue => Match(
            success => new JObject( "Value" , new JProperty( "Result" , nameof(CommandSuccess))),
            err => err.ResultLogValue
        );
}
public readonly record struct CommandSuccess
{
    public static readonly CommandSuccess Instance = new();
}
