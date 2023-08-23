

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using AtlConsultingIo.IntegrationOperations;

namespace AtlConsultingIo.Operations.Tests;

public class WebAppFactory : WebApplicationFactory<TestConsole.Program>
{
    protected override void ConfigureWebHost( IWebHostBuilder builder )
    {
        IConfigurationRoot config = null!;
        builder.ConfigureAppConfiguration( bldr =>
        {
            string fileName = "appsettings.test.json";
            bldr.AddJsonFile( Path.Combine( "JsonConfigurations" , fileName ) , optional: false );
            config = bldr.Build();
        } );

        var opsConfig = config.GetSection( nameof( IntegrationServiceConfiguration ) ).Get<IntegrationServiceConfiguration>();
        if( opsConfig?.Value is null )
            return;

        var integrations = opsConfig.Value.OperationsIntegrations;
        builder.ConfigureServices( services =>
        {
            var keyBuilder =
                new AppConfigurationKey( nameof(IntegrationServiceConfiguration) , AppConfigurationKey.WindowsDelimiter )
                .WithPath( nameof( IntegrationServiceConfiguration.Value ) )
                .WithPath( nameof( IntegrationServiceConfiguration.Options.OperationsIntegrations ));

            for ( int i = 0; i < integrations.Length; i++ )
            {
                var startupOpt = integrations[i];
                if( startupOpt is null )
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


                services.AddOptions<OperationsIntegration>( startupOpt.Name.Value )
                    .PostConfigure<IConfiguration>( ( opt , config ) =>
                    {
                        opt.Name = config.GetSection( nameKey).Get<IntegrationName>();
                        opt.LoggingOption = config.GetSection( loggingSectionKey ).Get<OperationLoggingOptions>();
                        opt.RetryOption = config.GetSection( retrySectionKey ).Get<OperationRetryOptions>();
                        opt.ClientConfiguration = startupOpt.Type switch
                        {
                            IntegrationType.SqlDatabase => config.GetSection( clientConfigurationKey ).Get<SqlClientConfiguration>(),
                            IntegrationType.AzureStorage => config.GetSection( clientConfigurationKey ).Get<StorageClientConfiguration>(),
                            IntegrationType.RestClient => config.GetSection( clientConfigurationKey ).Get<RestClientConfiguration>(),
                            _ => null!
                        };
                    } );
            }
        } );

    }
}