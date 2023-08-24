
using AtlConsultingIo.IntegrationOperations;

using Newtonsoft.Json.Linq;
namespace AtlConsultingIo.Operations.Tests;
public class OptionBindingTests
{

    [Fact]
    public void Can_Find_Parent_Section()
    {
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();

        IConfigurationSection section = configuration.GetSection( nameof(IntegrationServiceConfiguration) );
        section.Key.ShouldNotBeNullOrWhiteSpace();
        section.Path.ShouldNotBeNullOrWhiteSpace();

    }

    [Fact]
    public void Can_Find_Child_Section()
    {
        var key = $"{nameof(IntegrationServiceConfiguration)}:{nameof(IntegrationServiceConfiguration.Value)}";
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();

        IConfigurationSection section = configuration.GetSection( key );
        section.Key.ShouldNotBeNullOrWhiteSpace();
        section.Path.ShouldNotBeNullOrWhiteSpace();
    }

    [Fact]
    public void Can_Bind_To_Operations_Configuration()
    {
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();
        IntegrationServiceConfiguration? opsConfig = configuration.GetSection(nameof(IntegrationServiceConfiguration)).Get<IntegrationServiceConfiguration>();

        opsConfig.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Bind_To_Operations_Configuration_Value()
    {
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();
        IntegrationServiceConfiguration? opsConfig = configuration.GetSection(nameof(IntegrationServiceConfiguration)).Get<IntegrationServiceConfiguration>();
        opsConfig?.Value.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Bind_To_StorageLoggingConfiguration_Instance()
    {
        var configuration = SetupHelper.GetConfigurationsInstanceFromValidSettingsFile();
        configuration.Value?.ServiceLoggingOptions.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Bind_To_Integrations_Array()
    {
        var configuration = SetupHelper.GetConfigurationsInstanceFromValidSettingsFile();
        var integrations = configuration.Value?.IntegrationOptions;

        integrations.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Bind_To_IntegrationConfigurationInstance()
    {
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();

        var keyBuilder = new AppConfigurationKey( nameof( IntegrationServiceConfiguration) , AppConfigurationKey.WindowsDelimiter )
            .WithPath( nameof( IntegrationServiceConfiguration.Value ) )
            .WithPath( nameof( IntegrationServiceConfiguration.Options.IntegrationOptions ))
            .WithPath( "0" )
            .Build();

        string expectedKey = string.Join(':', 
            nameof(IntegrationServiceConfiguration), 
            nameof(IntegrationServiceConfiguration.Value), 
            nameof( IntegrationServiceConfiguration.Options.IntegrationOptions ),
            "0");

        string key = keyBuilder.Value;
        key.ShouldBeEquivalentTo( expectedKey );    

        var integration = configuration.GetSection( key ).Get<OperationsIntegration>();
        integration.ShouldNotBeNull();
        
    }

    [Fact]
    public void Can_Bind_To_Typed_Client_Configuration_To_Hierarchal_Key()
    {
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();

        AppConfigurationKey keyBuilder = 
            new AppConfigurationKey(nameof(IntegrationServiceConfiguration), AppConfigurationKey.WindowsDelimiter)
            .WithPath( nameof( IntegrationServiceConfiguration.Value ) )
            .WithPath( nameof( IntegrationServiceConfiguration.Options.IntegrationOptions ))
            .WithPath("0")
            .WithPath( nameof(OperationsIntegration.ClientConfiguration));

        string fullPath = keyBuilder.Build();

        SqlClientConfiguration? sqlConfiguration = configuration.GetSection( fullPath ).Get<SqlClientConfiguration>();
        sqlConfiguration.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Bind_To_Value_Structs()
    {
        var configuration = SetupHelper.GetConfigurationFromTestSettingsFile();

        AppConfigurationKey keyBuilder = 
            new AppConfigurationKey( nameof(IntegrationServiceConfiguration) , AppConfigurationKey.WindowsDelimiter )
            .WithPath( nameof( IntegrationServiceConfiguration.Value ) )
            .WithPath( nameof( IntegrationServiceConfiguration.Options.IntegrationOptions ))
            .WithPath("0")
            .WithPath( nameof(OperationsIntegration.ClientConfiguration));

        string key = keyBuilder.Build();
        SqlClientConfiguration? sqlConfig = configuration.GetSection( key ).Get<SqlClientConfiguration>();

        sqlConfig?.SqlConnectionString.IsEmpty.ShouldBeFalse();
    }

    [Fact]
    public void Can_Bind_With_Parent_Section()
    {
        AppConfigurationKey parentKey = new( "ParentSection", AppConfigurationKey.WindowsDelimiter );
        AppConfigurationKey configRootKey = parentKey.WithPath( nameof(IntegrationServiceConfiguration) ).Build();

        IConfigurationRoot configuration = SetupHelper.GetConfigurationFromNestedSettingsFile();
        IntegrationServiceConfiguration? opsConfig = configuration.GetSection( configRootKey ).Get<IntegrationServiceConfiguration>();
        opsConfig.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Bind_To_Integration_Configuration_Not_In_Array()
    {
        IConfigurationRoot root = SetupHelper.BuildConfigurationRootFromFile("appsettings.single.integration.json");
        OperationsIntegration? configuration = root.GetSection(nameof(OperationsIntegration)).Get<OperationsIntegration>();

        configuration.ShouldNotBeNull();
        configuration.Enabled.ShouldBeTrue();

    }

    [Fact]
    public void CanBindTo_IntegrationConfiguration_Enabled()
    {
        IConfigurationRoot root = SetupHelper.BuildConfigurationRootFromFile("appsettings.single.integration.json");
        var enabled = root.GetSection($"{nameof(OperationsIntegration)}:Enabled").Get<bool>();
        enabled.ShouldBeTrue();
    }

    
    [Fact]
    public void CanBindTo_IntegrationConfiguration_Value_Name()
    {
        IConfigurationRoot root = SetupHelper.BuildConfigurationRootFromFile("appsettings.single.integration.json");
        var name = root.GetSection($"{nameof(OperationsIntegration)}:Name").Get<IntegrationName>();
        name.IsEmpty.ShouldBeFalse();
    }

    
    [Fact]
    public void CanBindTo_IntegrationConfiguration_Value_IntegrationType()
    {
        IConfigurationRoot root = SetupHelper.BuildConfigurationRootFromFile("appsettings.single.integration.json");
        var type = root.GetSection($"{nameof(OperationsIntegration)}:Type").Get<string>();
        type.HasValue().ShouldBeTrue();
    }

    
    [Fact]
    public void CanBindTo_IntegrationConfiguration_Value_RetryOption()
    {
        IConfigurationRoot root = SetupHelper.BuildConfigurationRootFromFile("appsettings.single.integration.json");
        var opt = root.GetSection($"{nameof(OperationsIntegration)}:RetryOption").Get<OperationRetryOptions>();
        opt.ShouldNotBeNull();
    }

    
    [Fact]
    public void CanBindTo_IntegrationConfiguration_Value_LogOption()
    {
        IConfigurationRoot root = SetupHelper.BuildConfigurationRootFromFile("appsettings.single.integration.json");
        var opt = root.GetSection($"{nameof(OperationsIntegration)}:LoggingOption").Get<OperationLoggingOptions>();
        opt.ShouldNotBeNull();
    }

    [Fact]
    public void IntegrationType_Enum_Binds()
    {
        IntegrationServiceConfiguration configuration = SetupHelper.GetConfigurationsInstanceFromValidSettingsFile();
        configuration.Value.ShouldNotBeNull();

        OperationsIntegration intConfig = configuration.Value.IntegrationOptions.First();
        intConfig.Type.ShouldNotBe(IntegrationType.Unknown);
    }

    [Fact]
    public void DelayStrategy_Enum_Binds()
    {
        IntegrationServiceConfiguration configuration = SetupHelper.GetConfigurationsInstanceFromValidSettingsFile();
        configuration.Value.ShouldNotBeNull();

        OperationsIntegration intConfig = configuration.Value.IntegrationOptions.First();
        intConfig.RetryOption.Value.ShouldNotBeNull();
        intConfig.RetryOption.Value.RetryDelayStrategy.ShouldBe(RetryDelayStrategy.Constant);

    }

}
