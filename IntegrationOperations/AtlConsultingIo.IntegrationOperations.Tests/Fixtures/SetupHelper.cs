using AtlConsultingIo.IntegrationOperations;

namespace AtlConsultingIo.Operations.Tests;
internal static class SetupHelper
{
    internal static readonly string JsonFileDirectory = "Settings";
    public static IntegrationServiceConfiguration GetConfigurationsInstanceFromValidSettingsFile()
    {
        return GetConfigurationInstanceFromProvider( GetConfigurationFromTestSettingsFile() );
    }

    public static IntegrationServiceConfiguration GetConfigurationInstanceFromProvider( IConfigurationRoot configurationRoot )
    {
        var configuration = GetConfigurationFromTestSettingsFile();
        return configuration.GetSection( nameof( IntegrationServiceConfiguration ) ).Get<IntegrationServiceConfiguration>() ?? new();
    }

    public static IConfigurationRoot BuildConfigurationRootFromFile( string fileName )
    {
        return new ConfigurationBuilder()
        .AddJsonFile( Path.Combine( JsonFileDirectory , fileName ) , optional: false )
        .Build();
    }

    public static IConfigurationRoot GetConfigurationFromTestSettingsFile()
    {
        string fileName = "appsettings.test.json";
        return new ConfigurationBuilder()
            .AddJsonFile( Path.Combine( JsonFileDirectory , fileName ) , optional: false )
            .Build();
    }

    public static IConfigurationRoot GetConfigurationFromNestedSettingsFile()
    {
        string fileName = "appsettings.nested.json";
        return new ConfigurationBuilder()
        .AddJsonFile( Path.Combine( JsonFileDirectory , fileName ) , optional: false )
        .Build();
    }

    public static ServiceProvider BuildConfigurationsServiceProvicer()
    {
        string fileName = "appsettings.test.json";

        var configuration = new ConfigurationBuilder()
            .AddJsonFile( Path.Combine( JsonFileDirectory , fileName ) , optional: false )
            .Build();

        var keyBuilder =
            new AppConfigurationKey( nameof(IntegrationServiceConfiguration) , AppConfigurationKey.WindowsDelimiter )
            .WithPath( nameof( IntegrationServiceConfiguration.Value ) )
            .WithPath( nameof( IntegrationServiceConfiguration.Options.IntegrationOptions ));

        var services = new ServiceCollection();
        var opsConfig = configuration.GetSection( nameof( IntegrationServiceConfiguration ) ).Get<IntegrationServiceConfiguration>();
        if( opsConfig?.Value is null )
            return services.BuildServiceProvider();

        var integrations = opsConfig.Value.IntegrationOptions;
        if ( integrations is not null )
            for ( int i = 0; i < integrations.Length; i++ )
            {
                var startupOpt = integrations[i];
                if ( startupOpt is null )
                    continue;

                var indexKey = keyBuilder.WithPath(i.ToString());

                string nameKey = indexKey.WithPath(nameof( OperationsIntegration.Name )).Build();
                string loggingSectionKey =
                        indexKey
                        .WithPath( nameof(OperationsIntegration.LoggingOption ) )
                        .Build();

                string retrySectionKey =
                        indexKey
                        .WithPath( nameof(OperationsIntegration.RetryOption ) )
                        .Build();

                string clientConfigurationKey =
                        indexKey
                        .WithPath( nameof( OperationsIntegration.ClientConfiguration ))
                        .Build();

                services.AddSingleton<IConfiguration>( configuration );
                services.AddOptions<OperationsIntegration>( startupOpt.Name.Value )
                    .PostConfigure<IConfiguration>( ( opt , config ) =>
                    {
                        opt.Name = config.GetSection( nameKey ).Get<IntegrationName>();
                        opt.LoggingOption = config.GetSection( loggingSectionKey ).Get<OperationLoggingOptions>() ?? new();
                        opt.RetryOption = config.GetSection( retrySectionKey ).Get<OperationRetryOptions>() ?? new();
                        opt.ClientConfiguration = startupOpt.Type switch
                        {
                            IntegrationType.SqlDatabase => config.GetSection( clientConfigurationKey ).Get<SqlClientConfiguration>() ?? new(),
                            IntegrationType.AzureStorage => config.GetSection( clientConfigurationKey ).Get<StorageClientConfiguration>() ?? new(),
                            IntegrationType.RestClient => config.GetSection( clientConfigurationKey ).Get<RestClientConfiguration>() ?? new(),
                            _ => null!
                        };
                    } );
            }

        return services.BuildServiceProvider();
    }

    public static OperationLoggingOptions LoggingConfiguration => new OperationLoggingOptions
    {
        Value = new OperationLoggingOptions.Options
        {
            ExceptionEventsEnabled = false,
            ExceptionLogLevel = Microsoft.Extensions.Logging.LogLevel.Error,
            StorageLogResultTypes = new string[]
            {
                "TransactionFailure",
                "CommandFailure"
            }
        }
    };
    public static OperationRetryOptions RetryConfiguration => new OperationRetryOptions
    {
        Enabled = false,
        Value = new OperationRetryOptions.Options
        {
            RetryDelayStrategy = RetryDelayStrategy.Constant,
            MaxRetryAttempts = 0,
            InitialDelayMs = 0,
            MinDelayMs = 0,
            MaxDelayMs = 0,
            ConstantDelayMs = 0,
            MedianDelayMs = 0
        }
    };
}

