#region Usings

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Azure.Identity;
using Microsoft.Extensions.Logging;
using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.Options;

using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Hosting;
using System;
using Microsoft.VisualBasic;

#endregion
namespace AtlConsultingIo.IntegrationOperations;
public static partial class AppBuilderExtensions
{
    static readonly IntegrationOptionValidator _integrationOptionValidator = new();

    public static WebApplicationBuilder UseIntegrationOperations( this WebApplicationBuilder builder ,
        AppConfigurationConnection configurationConnectionString ,
        TimeSpan configurationCacheExpiration ,
        AppConfigurationKey? sectionKey )
    {
        builder.AddAzureConfigurationProvider( configurationCacheExpiration , configurationConnectionString , false );
        builder.LoadAzureConfigurationValues();

        return builder.UseIntegrationOperations( sectionKey );
    }

    public static WebApplicationBuilder UseIntegrationOperations( this WebApplicationBuilder builder ,
        AppConfigurationEndpoint configurationEndpoint ,
        TimeSpan configurationCacheExpiration ,
        AppConfigurationKey? sectionKey )
    {
        builder.AddAzureConfigurationProvider( configurationCacheExpiration , configurationEndpoint , true );
        builder.LoadAzureConfigurationValues();

        return builder.UseIntegrationOperations( sectionKey );
    }

    public static WebApplicationBuilder UseIntegrationOperations( this WebApplicationBuilder builder , AppConfigurationKey? sectionKey )
    {
        AppConfigurationKey serviceConfigurationKey =
            sectionKey.HasValue
                ? sectionKey.Value.WithPath( nameof( IntegrationServiceConfiguration ) ).Build()
                : new AppConfigurationKey ( nameof( IntegrationServiceConfiguration ) , AppConfigurationKey.WindowsDelimiter ).Build();

        IConfigurationRoot? appConfiguration = builder.Configuration;
        if ( appConfiguration is null )
            throw NullConfigurationException<IConfigurationRoot>();

        IntegrationServiceConfiguration configuration = GetIntegrationServiceConfiguration( builder, serviceConfigurationKey );
        AppConfigurationKey integrationsKey
            = serviceConfigurationKey
                .WithPath( nameof( IntegrationServiceConfiguration.Value ))
                .WithPath( nameof( IntegrationServiceConfiguration.Options.ServiceLoggingOptions ) )
                .Build();
        
        new IntegrationServiceConfigurationValidator().ValidateAndThrow( configuration );
        var integrationStartupOptions = configuration.Value!.OperationsIntegrations;
        for ( int index = 0; index < integrationStartupOptions.Length; index++ )
        {
            IntegrationOption integration = integrationStartupOptions[ index ];
            AppConfigurationKey indexKey = integrationsKey.WithPath( index.ToString() ).Build();

            integration.BindClientConfiguration( appConfiguration , indexKey );
            _integrationOptionValidator.ValidateAndThrow( integration );

            ConfigureOperationsIntegration( builder.Services, integration, indexKey );
        }

        if ( builder.Environment.IsProduction() )
            builder.Logging.AddFilter( typeof( IntegrationsService ).FullName ?? typeof( IntegrationsService ).Name , LogLevel.Warning );

        return builder;

    }

    public static WebApplicationBuilder UseLocalFileLogger( this WebApplicationBuilder builder , TextFileLoggingOptions options )
    {
        var validator = new TextFileLogOptionsValidator();
        validator.ValidateAndThrow( options );

        builder.Logging.AddFilter<TextFileLoggingProvider>( ( level ) => level >= options.LogLevelFilter && !level.None() );
        builder.Services.Configure<TextFileLoggingOptions>( o => options.Copy( o ) );
        builder.Services.TryAddSingleton<ILoggerProvider , TextFileLoggingProvider>();

        return builder;
    }
    public static WebApplicationBuilder UseApplicationInsights( this WebApplicationBuilder builder , AppInsightsConnection connection , bool useDebugLogger )
    {
        builder.Services.TryAddSingleton<ITelemetryInitializer , HostContextTelemetryInitializer>();

        builder.Logging.AddApplicationInsights();
        builder.Services.AddApplicationInsightsTelemetry( opts =>
        {
            opts.ConnectionString = connection;
            opts.EnableDebugLogger = useDebugLogger;
        } );

        return builder;
    }
    internal static IServiceCollection ConfigureStorageLoggingOption( this IServiceCollection services , AppConfigurationKey serviceConfigurationKey )
    {
        var storageOptKey = serviceConfigurationKey
                                .WithPath( nameof( IntegrationServiceConfiguration.Value ) )
                                .WithPath( nameof(IntegrationServiceConfiguration.Options.ServiceLoggingOptions) );

        services.AddOptions<IntegrationServiceLogSetting>()
            .PostConfigure<IConfiguration>( ( logConfig , appConfig ) =>
            {
                logConfig = appConfig.GetSection( storageOptKey ).Get<IntegrationServiceLogSetting>();
            } );

        return services;
    }
    internal static IServiceCollection ConfigureHostContextOption( this WebApplicationBuilder builder )
    {
        builder.Services.AddOptions<AzureHostContext>()
            .PostConfigure<IConfiguration>( ( ctx , config ) =>
            {
                var root = config as IConfigurationRoot;
                var internalCtx = root is null
                        ? new AzureHostContext().WithHostEnvironment( builder.Environment )
                        : new AzureHostContext( root ).WithHostEnvironment( builder.Environment );

                internalCtx.Copy( ctx );
            } );

        return builder.Services;
    }
    public static IServiceCollection RegisterIntegrationServices( this IServiceCollection services )
    {
        services
            .AddStorageClientFactory()
            .AddHttpSendHandler()
            .AddIntegrationOperationsLogger()
            .AddIntegrationOperationsService();

        return services;
    }
    public static IServiceCollection RegisterIntegrationOperations( this IServiceCollection services )
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        services
            .AddQueryOperations( assembly )
            .AddCommandOperations( assembly )
            .AddTransactionOperations( assembly )
            .AddValidatorsFromAssembly( assembly , ServiceLifetime.Singleton );

        SetNewtonsoftConvertSettings( assembly );

        return services;
    }
    internal static IServiceCollection AddIntegrationOperationsService( this IServiceCollection services )
    {
        services.TryAddScoped<IIntegrationsService , IntegrationsService>();
        return services;
    }
    internal static IServiceCollection AddIntegrationOperationsLogger( this IServiceCollection services )
    {
        services.TryAddScoped<IIntegrationsLogger , IntegrationsLogger>();
        return services;
    }
    internal static IServiceCollection AddHttpSendHandler( this IServiceCollection services )
    {
        services.TryAddTransient<IHttpSendHandler , HttpSendHandler>();
        return services;
    }
    internal static IServiceCollection AddStorageClientFactory( this IServiceCollection services )
    {
        services.TryAddScoped<IStorageClientFactory , StorageClientFactory>();
        return services;
    }
    internal static IServiceCollection AddQueryOperations( this IServiceCollection services , Assembly assembly )
    {
        var types = assembly.GetTypes().Where( t => !t.IsAbstract && t.IsIntegrationQueryOperation());
        if ( !types.HasItems() )
            return services;

        foreach ( var ty in types )
        {
            var interfaceImpl = ty.GetInterfaces().FirstOrDefault( i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IIntegrationQuery<>));
            if ( interfaceImpl is null )
                continue;

            services.AddTransient( interfaceImpl , ty );
        }

        return services;
    }
    internal static IServiceCollection AddCommandOperations( this IServiceCollection services , Assembly assembly )
    {
        var types = assembly.GetTypes().Where( t => !t.IsAbstract && t.IsIntegrationCommandOperation());
        if ( !types.HasItems() )
            return services;

        foreach ( var ty in types )
        {
            var interfaceImpl = ty.GetInterfaces().FirstOrDefault( i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IIntegrationCommand<>));
            if ( interfaceImpl is null )
                continue;

            services.AddTransient( interfaceImpl , ty );
        }
        return services;
    }
    internal static IServiceCollection AddTransactionOperations( this IServiceCollection services , Assembly assembly )
    {
        var types = assembly.GetTypes().Where( t => !t.IsAbstract && t.IsIntegrationTransactionOperation());
        if ( !types.HasItems() )
            return services;

        foreach ( var ty in types )
        {
            var interfaceImpl = ty.GetInterfaces().FirstOrDefault( i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IIntegrationTransaction<>));
            if ( interfaceImpl is null )
                continue;

            services.AddTransient( interfaceImpl , ty );
        }
        return services;
    }
    internal static void SetNewtonsoftConvertSettings( Assembly assembly )
    {
        if ( assembly.InitializeJsonConverters() is not List<JsonConverter> _converters )
            return;

        if ( !_converters.Any() )
            return;

        JsonConvert.DefaultSettings = () =>
        {
            JsonSerializerSettings settings = new()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            };

            foreach ( var converter in _converters )
                settings.Converters.Add( converter );

            return settings;
        };
    }


}
