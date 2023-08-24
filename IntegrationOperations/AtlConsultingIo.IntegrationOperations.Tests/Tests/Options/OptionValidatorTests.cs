using AtlConsultingIo.IntegrationOperations;

using Newtonsoft.Json.Linq;
namespace AtlConsultingIo.Operations.Tests;
public class OptionValidatorTests
{

    [Fact]
    public void Configuration_ValidationTest_FromProvider()
    {
        var configuration = SetupHelper.GetConfigurationsInstanceFromValidSettingsFile();
        var validator = new OperationsConfigurationValidator();

        var result = validator.Validate( configuration );
        result.IsValid.ShouldBeTrue();
    }



    [Fact]
    public void OperationsConfigurationTest_Negative()
    {
        var opsConfig = new IntegrationServiceConfiguration();
        var validator = new OperationsConfigurationValidator();
        validator.Validate( opsConfig ).IsValid.ShouldBeFalse();

        opsConfig.Value = new();
        validator.Validate( opsConfig ).IsValid.ShouldBeFalse();

    }

    [Fact]
    public void StorageLoggingConfigurationTest_Positive()
    {
        var validator = new StorageLoggingConfigurationValidator();
        IntegrationServiceLogConfiguration config = new IntegrationServiceLogConfiguration
        {
            StorageLoggingEnabled = true,
            Value = new IntegrationServiceLogConfiguration.Options
            {
                StorageLogConnection = new("MyAccountConnection"),
                UseBlobStorage = false,
                UseDocumentStorage = true,
                StorageLogResourceName = "LogContainerOrTableName"
            }
        };

        validator.Validate( config ).IsValid.ShouldBeTrue();
        config.StorageLoggingEnabled = false;
        validator.Validate( config ).IsValid.ShouldBeTrue();
    }


    [Fact]
    public void StorageLoggingConfigurationTest_Negative()
    {
        var validator = new StorageLoggingConfigurationValidator();
        IntegrationServiceLogConfiguration config = new IntegrationServiceLogConfiguration
        {
            StorageLoggingEnabled = true,
            Value = new IntegrationServiceLogConfiguration.Options
            {
                StorageLogConnection = new(""),
                UseBlobStorage = false,
                UseDocumentStorage = false,
                StorageLogResourceName = ""
            }
        };

        validator.Validate( config ).IsValid.ShouldBeFalse();

        config.Value.StorageLogConnection = new StorageAccountConnection( "MyStorageAccountConnection" );
        validator.Validate( config ).IsValid.ShouldBeFalse();

        config.Value.StorageLogResourceName = "LogsContainerOrTableName";
        validator.Validate( config ).IsValid.ShouldBeFalse();

        config.Value.UseBlobStorage = true;
        config.Value.UseDocumentStorage = true;
        validator.Validate( config ).IsValid.ShouldBeFalse();

    }




    [Fact] 
    public void Operations_Integration_Validator_Returns_Valid()
    {
        IConfigurationRoot root = SetupHelper.GetConfigurationFromTestSettingsFile();
        var opsConfig = root.GetSection(nameof(IntegrationServiceConfiguration)).Get<IntegrationServiceConfiguration>();
        opsConfig.ShouldNotBeNull();

        var baseKey = 
            new AppConfigurationKey( nameof(IntegrationServiceConfiguration), AppConfigurationKey.WindowsDelimiter )
            .WithPath( nameof(IntegrationServiceConfiguration.Value) )
            .WithPath( nameof(IntegrationServiceConfiguration.Options.IntegrationOptions) )
            .Build();

        var validator = new OperationsIntegrationValidator();
        for ( int i = 0; i < opsConfig.Value!.IntegrationOptions.Length; i++ )
        {
            var _value = opsConfig.Value!.IntegrationOptions[ i ];
            var _key = new AppConfigurationKey( baseKey.Value, baseKey.Delimiter )
                        .WithPath( i.ToString())
                        .WithPath( nameof(OperationsIntegration.ClientConfiguration) )
                        .Build()
                        .Value;

            OperationsIntegration _opt = new()
            {
                Name = _value.Name,
                LoggingOption = _value.LoggingOption,
                RetryOption = _value.RetryOption,
                ClientConfiguration = _value.Type switch
                {
                    IntegrationType.SqlDatabase => root.GetSection( _key ).Get<SqlClientConfiguration>() ?? SqlClientConfiguration.Default,
                    IntegrationType.AzureStorage => root.GetSection(_key ).Get<StorageClientConfiguration>() ?? StorageClientConfiguration.Default,
                    IntegrationType.RestClient => root.GetSection( _key ).Get<RestClientConfiguration>() ?? RestClientConfiguration.Default,
                    _ => null!
                }
            };

            var result = validator.Validate( _opt );
            result.IsValid.ShouldBeTrue();
        }
    }
}
