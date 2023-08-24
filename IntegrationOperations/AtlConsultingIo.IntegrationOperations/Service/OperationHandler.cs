using Azure;

using Microsoft.Data.SqlClient;

using Polly;
using Polly.Contrib.WaitAndRetry;

namespace AtlConsultingIo.IntegrationOperations;

internal sealed class OperationHandler
{
    private readonly IntegratedClientSettings _configuration;
    private readonly OperationRetrySetting.Options? _retryOption;

    private readonly OperationContext _opContext;
    private readonly IntegrationsLogger _logger;

    public OperationHandler(
        OperationContext operationContext ,
        IntegrationsLogger loggingService )
    {
        _opContext = operationContext;
        _logger = loggingService;

        _configuration = _opContext.IntegrationOption.ClientConfiguration;
        if ( _opContext.IntegrationOption.RetryOption.Enabled && _opContext.IntegrationOption.RetryOption.Value is not null )
            _retryOption = _opContext.IntegrationOption.RetryOption.Value;
    }

    public async Task<TransactionOperationResult<TResult>> ExecuteOperation<TRequest, TResult>( TRequest request , IIntegrationTransaction<TRequest> operation , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
        where TResult : class, new()
    {
        IAsyncPolicy executionPolicy = GetExecutionPolicy();

        PolicyResult<TransactionSuccess<TResult>> result
            = await executionPolicy.ExecuteAndCaptureAsync( async () => await operation.Execute<TResult>( request, _configuration, _logger.ServiceLogger , cancellationToken ));
        if ( result.Outcome.Equals( OutcomeType.Failure ) )
        {
            _logger.LogIntegrationException(_opContext, result.FinalException);
            return new OperationError( result.FinalException, OperationResultType.TransactionFailed );
        }

        return result.Result;
    }
    public async Task<CommandOperationResult> ExecuteOperation<TRequest>( TRequest request , IIntegrationCommand<TRequest> operation , CancellationToken cancellationToken ) 
        where TRequest : IntegrationRequest<TRequest>
    {
        IAsyncPolicy executionPolicy = GetExecutionPolicy( );
        
        PolicyResult result
            = await executionPolicy.ExecuteAndCaptureAsync( async () => await operation.Execute( request, _configuration, _logger.ServiceLogger, cancellationToken ));
        if ( result.Outcome.Equals( OutcomeType.Failure ) )
        {
            _logger.LogIntegrationException(_opContext, result.FinalException);
            return new OperationError( result.FinalException , OperationResultType.CommandFailed );
        }

        return CommandSuccess.Instance;
    }
    public async Task<QueryOperationResult<TResult>> ExecuteOperation<TRequest, TResult>( TRequest request , IIntegrationQuery<TRequest> operation , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
        where TResult : class, new()
    {
        IAsyncPolicy executionPolicy = GetExecutionPolicy();
        PolicyResult<QuerySuccess<TResult>> result
            = await executionPolicy.ExecuteAndCaptureAsync( async () => await operation.Execute<TResult>( request, _configuration, _logger.ServiceLogger, cancellationToken ));
        if ( result.Outcome.Equals( OutcomeType.Failure ) )
        {
            _logger.LogIntegrationException(_opContext, result.FinalException);
            return new OperationError( result.FinalException, OperationResultType.QueryFailed );
        }

        return result.Result;
    }
    private IAsyncPolicy GetExecutionPolicy( )
    {
        if ( _retryOption is null )
            return Policy.NoOpAsync();

        return Policy.Handle( ExceptionFilter )
            .WaitAndRetryAsync( 
                    _retryOption.MaxRetryAttempts , 
                    GetDurationProvider( _retryOption ) , 
                    ( err , ts , count , ctx ) => _logger.LogIntegrationException( _opContext, err ) 
                );
    }
    private Func<int,TimeSpan> GetDurationProvider( OperationRetrySetting.Options retryOptions )
    {
        IEnumerable<TimeSpan> intervals = retryOptions.RetryDelayStrategy switch
        {
            RetryDelayStrategy.Constant => Backoff.ConstantBackoff( retryOptions.ConstantDelayInMilliseconds , retryOptions.MaxRetryAttempts ),
            RetryDelayStrategy.JitterV2 => Backoff.DecorrelatedJitterBackoffV2( retryOptions.MedianDelayInMilliseconds , retryOptions.MaxRetryAttempts ),
            RetryDelayStrategy.Exponential => Backoff.ExponentialBackoff( retryOptions.InitialDelayInMilliseconds , retryOptions.MaxRetryAttempts ),
            RetryDelayStrategy.Linear => Backoff.LinearBackoff( retryOptions.InitialDelayInMilliseconds , retryOptions.MaxRetryAttempts ),
            _ => Backoff.AwsDecorrelatedJitterBackoff( retryOptions.MinDelayInMilliseconds , retryOptions.MaxDelayInMilliseconds , retryOptions.MaxRetryAttempts )
        };

        return ( attemptNo ) => intervals.ElementAt( attemptNo - 1 ); 
    }
    private Func<Exception , bool> ExceptionFilter => ( exception ) =>
    {
        Type exType = exception.GetType();
        return _configuration.Match(
                sql => exType.Equals( typeof( SqlException ) ) || exType.Equals( typeof( TimeoutException ) ) ,
                storage => exType.Equals( typeof( RequestFailedException ) ) ,
                rest => exType.Equals( typeof( HttpSendException ) )
            );
    };

}




