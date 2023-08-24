#region Usings

using Azure.Identity;

using FluentValidation;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
#endregion

namespace AtlConsultingIo.IntegrationOperations;

public static partial class AppBuilderExtensions
{
    #region Azure App Configuration Service 

    internal static void AddAzureConfigurationProvider( this WebApplicationBuilder builder , TimeSpan cacheExpiration , string connectionValue , bool isEndpointConnection )
    {
        var configure
            = isEndpointConnection ?
                AddAzureConfigurationServiceUsingEndpoint( connectionValue, cacheExpiration , InitializeHostContext( builder ) ) :
                AddAzureConfigurationServiceUsingConnectionString( connectionValue, cacheExpiration, InitializeHostContext(builder) );

        builder.Configuration.AddAzureAppConfiguration( configure );
    }
    internal static void LoadAzureConfigurationValues( this WebApplicationBuilder builder )
    {
        if ( builder.Configuration is not IConfigurationRoot root )
            throw new ApplicationException( "Could not resolve reference to IConfigurationRoot" );

        root.Reload();
    }
    internal static Action<AzureAppConfigurationOptions> AddAzureConfigurationServiceUsingConnectionString( string connectionString , TimeSpan cacheExpiration , AzureHostContext context )
        => ( options ) =>
        {
            options.Connect( connectionString )
                .ConfigureRefresh( refresh =>
                {
                    refresh.Register( GetConfigurationRefreshKey( context ) , refreshAll: true )
                        .SetCacheExpiration( cacheExpiration );
                } );
        };
    internal static Action<AzureAppConfigurationOptions> AddAzureConfigurationServiceUsingEndpoint( string endpoint , TimeSpan cacheExpiration , AzureHostContext context )
        => ( options ) =>
        {
            options.Connect( new Uri( endpoint ) , new DefaultAzureCredential() )
                .ConfigureRefresh( refresh =>
                {
                    refresh.Register( GetConfigurationRefreshKey( context ) , refreshAll: true )
                        .SetCacheExpiration( cacheExpiration );
                } );
        };
    internal static string GetConfigurationRefreshKey( AzureHostContext context )
        => string.Join( ":" ,
            context.ApplicationName?.AlphaNumericCharactersOnly().EmptyIfNull() ,
            context.InstanceID.AlphaNumericCharactersOnly() ,
            "Sentinel"
            );

    #endregion

    #region Operations Reflection Utility

    internal static bool IsIntegrationCommandOperation( this Type type )
    {
        return type.GetInterfaces()
            .Any( interfaceType =>
                interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition() == typeof( IIntegrationCommand<> ) );
    }
    internal static bool IsIntegrationQueryOperation( this Type type )
    {
        return type.GetInterfaces()
            .Any( interfaceType =>
                interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition() == typeof( IIntegrationQuery<> ) );
    }
    internal static bool IsIntegrationTransactionOperation( this Type type )
    {
        return type.GetInterfaces()
            .Any( interfaceType =>
                interfaceType.IsGenericType &&
                interfaceType.GetGenericTypeDefinition() == typeof( IIntegrationTransaction<> ) );
    }

    #endregion

    #region Startup Options Helpers
    internal static void ConfigureOperationsIntegration( IServiceCollection services ,  IntegrationOption startupInstance , AppConfigurationKey configurationIndexKey )
    {
        var (logKey, retryKey, clientKey) = (
            configurationIndexKey.WithPath( nameof( IntegrationOption.LoggingOption ) ).Build(),
            configurationIndexKey.WithPath( nameof( IntegrationOption.RetryOption ) ).Build(),
            configurationIndexKey.WithPath( nameof( IntegrationOption.ClientConfiguration ) ).Build()
            );

        services.AddOptions<IntegrationOption>( startupInstance.Name )
            .PostConfigure<IConfiguration>( ( integrationConfig , appConfig ) =>
            {
                integrationConfig.Name = startupInstance.Name;
                integrationConfig.LoggingOption = appConfig.GetSection( logKey ).Get<OperationLogSetting>() ?? OperationLogSetting.Default;
                integrationConfig.RetryOption = appConfig.GetSection( retryKey ).Get<OperationRetrySetting>() ?? OperationRetrySetting.Default;
                integrationConfig.Type = startupInstance.Type;
                integrationConfig.ClientConfiguration = startupInstance.Type switch
                {
                    IntegrationType.SqlDatabase => appConfig.GetSection( clientKey ).Get<SqlClientConfiguration>() ?? SqlClientConfiguration.Default,
                    IntegrationType.AzureStorage => appConfig.GetSection( clientKey ).Get<StorageClientConfiguration>() ?? StorageClientConfiguration.Default,
                    IntegrationType.RestClient => appConfig.GetSection( clientKey ).Get<RestClientConfiguration>() ?? RestClientConfiguration.Default,
                    _ => IntegratedClientSettings.Default
                };
            } );

        services.AddOptions<OperationLogSetting>( startupInstance.Name )
            .PostConfigure<IConfiguration>( ( logOption, appConfiguration ) =>
            {
                OperationLogSetting instance = appConfiguration.GetSection( logKey ).Get<OperationLogSetting>() ?? OperationLogSetting.Default;
                instance.Copy( logOption );
            } );

        if ( startupInstance.Type.Equals( IntegrationType.RestClient ) )
            ConfigureNamedHttpClient( services , startupInstance.Name );
    }
    internal static void ConfigureNamedHttpClient( IServiceCollection services , IntegrationKey integrationName )
    {
        services.TryAddTransient<RequestAuthenticationHandler>();
        services.AddHttpClient( integrationName , ( provider , client ) =>
        {
            var monitor = provider.GetRequiredService<IOptionsMonitor<IntegrationOption>>();
            var clientConfig = monitor.Get( integrationName ).ClientConfiguration;

            var restOpts = (RestClientConfiguration?)clientConfig;
            if ( restOpts is null )
                throw NullConfigurationException<RestClientConfiguration>();

            client.BaseAddress = new Uri( restOpts.BaseUrl );
            client.DefaultRequestHeaders.Add( "User-Agent" , restOpts.UserAgent );

            if ( restOpts.CustomHeaders is not null )
                foreach ( var header in restOpts.CustomHeaders )
                    if ( client.DefaultRequestHeaders.TryAddWithoutValidation( header.Key , header.Value ) == false && restOpts.CustomHeadersRequired )
                        throw new ArgumentException( $"Invalid header detected.  Key: {header.Key} | Value: {header.Value}" );
        } ).AddHttpMessageHandler<RequestAuthenticationHandler>();

    }
    internal static IntegrationServiceConfiguration GetIntegrationServiceConfiguration( WebApplicationBuilder builder , AppConfigurationKey serviceConfigurationKey )
    {
        IntegrationServiceConfiguration configuration
            = builder.Configuration
                     .GetSection( serviceConfigurationKey )
                     .Get<IntegrationServiceConfiguration>() ?? throw NullConfigurationException<IntegrationServiceConfiguration>();

        ValidateIntegrationServiceConfiguration( configuration );
        return configuration;
    }
    internal static void ValidateIntegrationServiceConfiguration( IntegrationServiceConfiguration serviceConfiguration )
    {
        new IntegrationServiceConfigurationValidator()
            .ValidateAndThrow( serviceConfiguration );

        return;
    }
    internal static ApplicationException NullConfigurationException<T>()
        => new( $"Required configuration {typeof( T ).Name} is missing.  Cannot configure integration operations." );
    internal static AzureHostContext InitializeHostContext( WebApplicationBuilder builder )
    {
        IConfigurationRoot? root = builder.Configuration as IConfigurationRoot;
        return root is null
            ? new AzureHostContext().WithHostEnvironment( builder.Environment )
            : new AzureHostContext( root ).WithHostEnvironment( builder.Environment );
    }
    internal static void BindClientConfiguration( this IntegrationOption initialBinding , IConfigurationRoot appConfiguration , AppConfigurationKey optionIndexKey )
    {
        AppConfigurationKey clientConfigurationKey
                = optionIndexKey
                    .WithPath( nameof( IntegrationOption.ClientConfigurationBindingKey ) )
                    .Build();

        IntegratedClientSettings clientConfiguration = initialBinding.Type switch
        {
            IntegrationType.SqlDatabase => appConfiguration.GetSection( clientConfigurationKey.Value ).Get<SqlClientConfiguration>() ?? SqlClientConfiguration.Default,
            IntegrationType.AzureStorage => appConfiguration.GetSection( clientConfigurationKey.Value ).Get<StorageClientConfiguration>() ?? StorageClientConfiguration.Default,
            IntegrationType.RestClient => appConfiguration.GetSection( clientConfigurationKey.Value ).Get<RestClientConfiguration>() ?? RestClientConfiguration.Default,
            _ => null!
        };

        if( clientConfiguration is null )
            throw NullConfigurationException<IntegratedClientSettings>();

        initialBinding.ClientConfiguration = clientConfiguration;
    }
    #endregion
}
