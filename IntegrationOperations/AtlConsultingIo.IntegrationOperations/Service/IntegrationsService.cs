using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AtlConsultingIo.IntegrationOperations;
public class IntegrationsService : IIntegrationsService
{
    private IOptionsSnapshot<IntegrationOption> _integrations;
    private IOptionsSnapshot<IntegrationServiceLogSetting> _logOptions;

    private IServiceProvider _container ;
    private IntegrationsLogger _loggingService;

    public IntegrationsService( IServiceProvider containerServices )
    {
        _container = containerServices;

        _logOptions = _container.GetRequiredService<IOptionsSnapshot<IntegrationServiceLogSetting>>();
        _integrations = _container.GetRequiredService<IOptionsSnapshot<IntegrationOption>>();
        _loggingService = _container.GetRequiredService<IntegrationsLogger>();

    }

    public async Task<CommandOperationResult> ExecuteIntegrationCommand<TRequest>( IntegrationRequest<TRequest> integrationRequest , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
    {
        OperationContext context = integrationRequest;

        try
        {
            _loggingService.ServiceLogger.RequestReceivedTrace( context , nameof( ExecuteIntegrationCommand ) );

            IntegrationOption integration = _integrations.Get( integrationRequest.Key );
            context = context with { IntegrationOption = integration };
            OperationHandler handler = new(
                    operationContext: context,
                    loggingService: _loggingService
                );

            IIntegrationCommand<TRequest> operation = ResolveCommandOperation<TRequest>();
            var result = await handler.ExecuteOperation<TRequest>( (TRequest)integrationRequest , operation , cancellationToken );

            await _loggingService.CreateExecutionLog(
                    integration.Type ,
                    integrationRequest ,
                    result
                );

            _loggingService.ServiceLogger.RequestCompleteTrace( context , nameof( ExecuteIntegrationCommand ) , result );
            return result;
        }
        catch ( Exception operationError )
        {
            _loggingService.LogServiceException( context , operationError );

            OperationError result = new ( operationError, OperationResultType.CommandFailed );
            await _loggingService.CreateExecutionLog(
                    context.IntegrationOption.Type ,
                    integrationRequest ,
                    result
                );

            _loggingService.ServiceLogger.RequestCompleteTrace( context , nameof( ExecuteIntegrationCommand ) , result );
            return result;
        }
    }
    public async Task<QueryOperationResult<TResult>> ExecuteIntegrationQuery<TRequest, TResult>( IntegrationRequest<TRequest> request , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
        where TResult : class, new()
    {
        OperationContext context = request;

        try
        {
            _loggingService.ServiceLogger.RequestReceivedTrace( context , nameof( ExecuteIntegrationQuery ) );

            IntegrationOption configuration = _integrations.Get( request.Key );
            context = context with { IntegrationOption = configuration };
            OperationHandler handler = new(
                    operationContext: context,
                    loggingService: _loggingService
                );

            IIntegrationQuery<TRequest> operation = ResolveQueryOperation<TRequest>();
            QueryOperationResult<TResult> result = await handler.ExecuteOperation<TRequest , TResult>( (TRequest)request , operation , cancellationToken );

            await _loggingService.CreateExecutionLog(
                    configuration.Type ,
                    request ,
                    result
                );

            _loggingService.ServiceLogger.RequestCompleteTrace( context , nameof( ExecuteIntegrationQuery ) , result );
            return result;
        }
        catch ( Exception operationError )
        {
            _loggingService.LogServiceException( context , operationError );

            OperationError result = new ( operationError, OperationResultType.QueryFailed );
            await _loggingService.CreateExecutionLog(
                    context.IntegrationOption.Type ,
                    request ,
                    result
                );

            _loggingService.ServiceLogger.RequestCompleteTrace( context , nameof( ExecuteIntegrationQuery ) , result );
            return result;
        }
    }
    public async Task<TransactionOperationResult<TResult>> ExecuteIntegtrationTransaction<TRequest, TResult>( IntegrationRequest<TRequest> request , CancellationToken cancellationToken )
        where TRequest : IntegrationRequest<TRequest>
        where TResult : class, new()
    {
        OperationContext context = request;
        try
        {
            _loggingService.ServiceLogger.RequestReceivedTrace( context , nameof( ExecuteIntegtrationTransaction ) );

            IntegrationOption integration = _integrations.Get( request.Key );
            context = context with { IntegrationOption = integration };
            OperationHandler handler = new(
                    operationContext: context,
                    loggingService: _loggingService
                );

            IIntegrationTransaction<TRequest> operation = ResolveTransactionOperation<TRequest>();
            TransactionOperationResult<TResult> result = await handler.ExecuteOperation<TRequest , TResult>( (TRequest) request , operation , cancellationToken );

            await _loggingService.CreateExecutionLog(
                    integration.Type ,
                    request ,
                    result
                );

            _loggingService.ServiceLogger.RequestCompleteTrace( context , nameof( ExecuteIntegtrationTransaction ) , result );
            return result;
        }
        catch ( Exception operationError )
        {
            _loggingService.LogServiceException( context , operationError );

            OperationError result = new ( operationError, OperationResultType.TransactionFailed );
            await _loggingService.CreateExecutionLog(
                    context.IntegrationOption.Type ,
                    request ,
                    result
                );

            _loggingService.ServiceLogger.RequestCompleteTrace( context , nameof( ExecuteIntegtrationTransaction ) , result );
            return result;
        }

    }
    private IIntegrationQuery<TRequest> ResolveQueryOperation<TRequest>()
        where TRequest : IntegrationRequest<TRequest>
    {
        Type requestType = typeof(TRequest);
        var interfaceImpl = typeof(IIntegrationQuery<>).MakeGenericType(requestType);

        var query = _container.GetService(interfaceImpl);

        var typed = query is null ? null : query as IIntegrationQuery<TRequest>;
        return typed is not null ? typed :
            throw new InvalidOperationException( OperationNotFoundError( requestType ) );
    }
    private IIntegrationCommand<TRequest> ResolveCommandOperation<TRequest>()
        where TRequest : IntegrationRequest<TRequest>
    {
        Type requestType = typeof(TRequest);
        var interfaceImpl = typeof(IIntegrationCommand<>).MakeGenericType(requestType);

        var command = _container.GetService(interfaceImpl);

        var typed = command is null ? null : command as IIntegrationCommand<TRequest>;
        return typed is not null ? typed :
            throw new InvalidOperationException( OperationNotFoundError( requestType ) );

    }
    private IIntegrationTransaction<TRequest> ResolveTransactionOperation<TRequest>()
        where TRequest : IntegrationRequest<TRequest>
    {
        Type requestType = typeof(TRequest);
        var interfaceImpl = typeof(IIntegrationTransaction<>).MakeGenericType(requestType);

        var transaction = _container.GetService(interfaceImpl);

        var typed = transaction is null ? null : transaction as IIntegrationTransaction<TRequest>;
        return typed is not null ? typed :
            throw new InvalidOperationException( OperationNotFoundError( requestType ) );

    }
    private static string OperationNotFoundError( Type operationRequestType )
        => $"Could not resolve IIntegrationCommand<> implementation for OperationRequestType {operationRequestType.FullName ?? operationRequestType.Name} from the DI container.";


}
