using Azure.Data.Tables;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Metrics;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using System.Collections.Concurrent;
using System.Reflection;

namespace AtlConsultingIo.IntegrationOperations;
public sealed class IntegrationsLogger : IIntegrationsLogger
{

    private readonly IStorageClientFactory _storageClientFactory;
    private readonly ILoggerFactory _loggerFactory;

    private readonly IOptionsMonitor<OperationLogSetting> _integrationLogOptions;
    private readonly IOptionsMonitor<IntegrationServiceLogSetting> _storageLoggingOption;


    private readonly TelemetryClient? _appInsights;
    private static readonly ConcurrentDictionary<string,Metric> _metrics = new();
    private static string _metricNamespace { get; set; } = String.Empty;

    public IntegrationsLogger(
            IStorageClientFactory clientFactory ,
            ILoggerFactory loggerFactory ,
            TelemetryClient telemetryClient ,
            IOptionsMonitor<OperationLogSetting> operationLogOptions ,
            IOptionsMonitor<IntegrationServiceLogSetting> storageLogOption
         )
    {
        _storageLoggingOption = storageLogOption;
        _integrationLogOptions = operationLogOptions;
        _appInsights = telemetryClient;
        _storageClientFactory = clientFactory;
        _loggerFactory = loggerFactory;
        ServiceLogger = _loggerFactory.CreateLogger<IntegrationsService>();

        if ( string.IsNullOrWhiteSpace( _metricNamespace ) )
        {
            string? name = Assembly.GetEntryAssembly()?.GetName().Name;
            _metricNamespace = !string.IsNullOrWhiteSpace( name )
                                ? name
                                : Assembly.GetExecutingAssembly().GetName().Name ?? nameof( AtlConsultingIo );
        }
    }

    public IntegrationsLogger(
            IStorageClientFactory clientFactory ,
            ILoggerFactory loggerFactory ,
            IOptionsMonitor<OperationLogSetting> operationLogOptions ,
            IOptionsMonitor<IntegrationServiceLogSetting> storageLogOption
         )
    {
        _storageLoggingOption = storageLogOption;
        _integrationLogOptions = operationLogOptions;
        _storageClientFactory = clientFactory;
        _loggerFactory = loggerFactory;
        ServiceLogger = _loggerFactory.CreateLogger<IntegrationsService>();

        if ( string.IsNullOrWhiteSpace( _metricNamespace ) )
        {
            string? name = Assembly.GetEntryAssembly()?.GetName().Name;
            _metricNamespace = !string.IsNullOrWhiteSpace( name )
                                ? name
                                : Assembly.GetExecutingAssembly().GetName().Name ?? nameof( AtlConsultingIo );
        }
    }

    public readonly ILogger ServiceLogger;
    public async ValueTask CreateExecutionLog<TRequest>(
        IntegrationType integrationType ,
        IntegrationRequest<TRequest> operationRequest ,
        IIntegrationOperationResult operationResult )
        where TRequest : class
    {
        var option = _integrationLogOptions.Get( operationRequest.Key ).GetOptionOrDefault();
        if ( option.EnabledLogTypes.Contains( operationResult.ResultType ) )
            await TryAsync( async () =>
            {
                OperationStorageLog storageLog = operationRequest;
                storageLog = storageLog with
                {
                    IntegrationType = integrationType ,
                    ResultType = operationResult.ResultType ,
                    ResultLogData = operationResult.ResultLogValue
                };

                await Save( storageLog );
            } );

        TrackResult( new OperationResultTelemetry( operationRequest.Key , operationResult.ResultType , operationRequest.GetType().Name ) );
    }

    public void LogIntegrationException( OperationContext context , Exception exception )
    {
        var logOptions = _integrationLogOptions.Get( context.IntegrationName ).GetOptionOrDefault();
        var exLog = new OperationExceptionLog(
                Exception: exception,
                LogLevel: logOptions.ExceptionLogLevel,
                IntegrationName: context.IntegrationName,
                ContextID: context.ContextID,
                OperationType: context.OperationType
            );

        ILogger logger =_loggerFactory.CreateLogger( context.IntegrationName );
        logger.OperationError( exLog );

        if ( logOptions.ExceptionEventsEnabled )
            TrackError( new OperationErrorTelemetry( exLog , context.IntegrationOption.Type , logOptions.CustomEventProperties ) );
    }
    public void LogServiceException( OperationContext context , Exception exception )
    {
        ServiceLogger.OperationError( new OperationExceptionLog(
                Exception: exception ,
                LogLevel: LogLevel.Error ,
                IntegrationName: context.IntegrationName ,
                ContextID: context.ContextID ,
                OperationType: context.OperationType
            ) );
    }

    #region Storage Logging

    async Task Save( OperationStorageLog log )
    {
        await TryAsync( async () =>
        {
            if ( !_storageLoggingOption.CurrentValue.StorageLoggingEnabled )
                return;

            StorageResourceClient resourceClient = await GetResourceClient();
            Func<Task> save = _storageLoggingOption.CurrentValue.GetValueOrDefault().UseDocumentStorage
                        ? async() => await InsertOperationDocumentLog( log, (TableClient?)resourceClient)
                        : async() => await InsertOperationBlobLog( log, (BlobContainerClient?)resourceClient);

            await save();
        } );
    }
    async Task<StorageResourceClient> GetResourceClient()
    {
        var opt = _storageLoggingOption.CurrentValue.GetValueOrDefault();
        var req = new StorageClientRequest
        (
            AccountConnection: opt.StorageLogConnection,
            ResourceId: GetResourceID( opt ),
            ResourceType : opt.UseDocumentStorage ? StorageServiceType.StorageTable : StorageServiceType.StorageBlob,
            IntegrationName : new IntegrationKey( "StorageLoggingIntegration" )
        );

        return await _storageClientFactory.CreateResourceClientAsync( req , CancellationToken.None );
    }
    static IResourceID GetResourceID( IntegrationServiceLogSetting.Options options )
        => options.UseDocumentStorage
            ? new StorageTableName( options.StorageLogResourceName.EmptyIfNull() )
            : new StorageBlobContainerName( options.StorageLogResourceName.EmptyIfNull() );
    async Task InsertOperationBlobLog( OperationStorageLog log , BlobContainerClient? logContainerClient )
    {
        if ( logContainerClient is null )
            throw new ArgumentNullException( $"Resource client instance is not a BlobContainerClient, cannot create operation log blob." );

        await TryAsync( async () =>
        {
            var tags = new Dictionary<string, string>
            {
                [ nameof( OperationStorageLog.IntegrationType ) ] = log.IntegrationType.ToString(),
                [ nameof( OperationStorageLog.OperationType ) ] = log.OperationType,
                [ nameof( OperationStorageLog.ResultType ) ] = log.ResultType.ToString(),
                [ nameof( OperationStorageLog.IntegrationName ) ] = log.IntegrationName.Value
            };

            var name = new StorageBlobName( string.Join("/", LogNameDate, log.IntegrationName.Value.AlphaNumericCharactersOnly(), log.ContextID.Value.AlphaNumericCharactersOnly())).WithJsonFileExtension();
            BlobClient blobClient = logContainerClient.GetBlobClient(name);
            _ = await blobClient.UploadAsync(
                    new BinaryData( log ) ,
                    new BlobUploadOptions()
                    {
                        Tags = tags ,
                        Conditions = null
                    }
                ).ConfigureAwait( false );
        } );
    }
    async Task InsertOperationDocumentLog( OperationStorageLog log , TableClient? storageTableClient )
    {
        if ( storageTableClient is null )
            throw new ArgumentNullException( $"Resource client instance is not a BlobContainerClient, cannot create operation log document." );

        await TryAsync( async () =>
        {
            var entity = new TableEntity(
                        partitionKey: string.Join('_', log.IntegrationName, log.OperationType ) ,
                        rowKey: string.Join( '_' , LogNameDate, log.ContextID )  )
                        {
                            { nameof( OperationStorageLog.IntegrationName ) , log.IntegrationName } ,
                            { nameof( OperationStorageLog.IntegrationType ) , log.IntegrationType.ToString() } ,
                            { nameof( OperationStorageLog.ContextID ) , log.ContextID } ,
                            { nameof( OperationStorageLog.OperationType ) , log.OperationType } ,
                            { nameof( OperationStorageLog.RequestLogData ) , log.ResultLogData } ,
                            { nameof( OperationStorageLog.ResultType ) ,  log.ResultType.ToString() } ,
                            { nameof( OperationStorageLog.ResultLogData ) ,  log.ResultLogData is not null ? log.ResultLogData : OperationStorageLog.NullLogData }
                        };

            _ = await storageTableClient.UpsertEntityAsync( entity , TableUpdateMode.Merge ).ConfigureAwait( false );
        } );
    }
    private static string LogNameDate => string.Concat( DateTime.UtcNow.Year , DateTime.UtcNow.Month , DateTime.UtcNow.Day );

    #endregion

    #region AppInsights Telemetry

    void TrackResult( OperationResultTelemetry telemetryItem )
    {
        Try( () =>
        {
            if ( _appInsights is null )
                return;

            var exists = _metrics.TryGetValue( telemetryItem.MetricName, out Metric? metricValue ) ;
            Metric metric = exists ? metricValue! : _appInsights.GetMetric( GetMetricId( telemetryItem ) );

            metric.TrackValue(
                    metricValue: 1 ,
                    dimension1Value: telemetryItem.ResultType.ToString() ,
                    dimension2Value: telemetryItem.OperationType
                );

            if ( !exists )
                _ = _metrics.TryAdd( telemetryItem.MetricName , metric );
        } );
    }
    void TrackError( OperationErrorTelemetry telemetryItem )
    {
        Try( () =>
        {
            if ( _appInsights is null )
                return;

            var exists = _metrics.TryGetValue( telemetryItem.MetricName, out Metric? metricValue ) ;
            Metric metric = exists ? metricValue! : _appInsights.GetMetric( GetMetricId(telemetryItem) );

            metric.TrackValue(
                    metricValue: 1 ,
                    dimension1Value: telemetryItem.IntegrationType.ToString() ,
                    dimension2Value: telemetryItem.OperationType ,
                    dimension3Value: telemetryItem.ExceptionType
                );

            if ( !exists )
                _ = _metrics.TryAdd( telemetryItem.MetricName , metric );

            _appInsights.TrackEvent( telemetryItem );

        } );
    }
    MetricIdentifier GetMetricId( OperationErrorTelemetry errorEvent )
    {
        return new MetricIdentifier(
                metricNamespace: _metricNamespace ,
                metricId: errorEvent.MetricName ,
                dimension1Name: nameof( OperationErrorTelemetry.IntegrationType ) ,
                dimension2Name: nameof( OperationErrorTelemetry.OperationType ) ,
                dimension3Name: nameof( OperationErrorTelemetry.ExceptionType )
            );
    }
    MetricIdentifier GetMetricId( OperationResultTelemetry executionTelemetry )
    {
        return new MetricIdentifier(
                metricNamespace: _metricNamespace ,
                metricId: executionTelemetry.MetricName ,
                dimension1Name: nameof( OperationResultTelemetry.ResultType ) ,
                dimension2Name: nameof( OperationResultTelemetry.OperationType )
            );
    }

    #endregion

    #region Exception Wrappers

    static void Try( Action action )
    {
        try { action(); }
        catch ( Exception ) { }
    }
    async Task TryAsync( Func<Task> func )
    {
        try { await func(); }
        catch ( Exception err ) { ServiceLogger.LogWarning( err , "Source: {ServiceName}" , nameof( IntegrationsLogger ) ); }
    }
    async Task<TResult?> TryAsync<TResult>( Func<Task<TResult>> func )
    {
        try { return await func(); }
        catch ( Exception err )
        {
            ServiceLogger.LogWarning( err , "Source: {ServiceName}" , nameof( IntegrationsLogger ) );
            return default;
        }
    }

    #endregion
}


