

using Microsoft.Extensions.Options;
namespace AtlConsultingIo.Operations.Tests;

public class OptionsDependencyTests 
{
    [Fact]
    public void Can_Resolve_Operation_Monitor_From_Container()
    {
        var provider = SetupHelper.BuildConfigurationsServiceProvicer();
        var monitor = provider.GetService<IOptionsMonitor<OperationsIntegration>>();
        monitor.ShouldNotBeNull();
    }

    [Fact]
    public void Can_Resolve_Named_Option_From_Monitor()
    {
        var knownName = new IntegrationName("MyDatabaseName");
        var provider = SetupHelper.BuildConfigurationsServiceProvicer();
        var monitor = provider.GetRequiredService<IOptionsMonitor<OperationsIntegration>>();

        var integrationOpt = monitor.Get( knownName.Value );
        integrationOpt.ShouldNotBeNull();
        integrationOpt.Name.Equals( knownName ).ShouldBeTrue();
    }

    [Fact]
    public void OperationsIntegration_ClientConfiguration_Value_IsSqlClient()
    {
        var knownName = new IntegrationName("MyDatabaseName");
        var provider = SetupHelper.BuildConfigurationsServiceProvicer();
        var monitor = provider.GetRequiredService<IOptionsMonitor<OperationsIntegration>>();

        var integrationOpt = monitor.Get( knownName.Value );
        integrationOpt.ShouldNotBeNull();
        integrationOpt.ClientConfiguration.IsSqlConfiguration.ShouldBeTrue();
    }

    [Fact]
    public void OperationsIntegration_ClientConfiguration_Value_IsStorageClient()
    {
        var knownName = new IntegrationName("MyStorageAccountName");
        var provider = SetupHelper.BuildConfigurationsServiceProvicer();
        var monitor = provider.GetRequiredService<IOptionsMonitor<OperationsIntegration>>();

        var integrationOpt = monitor.Get( knownName.Value );
        integrationOpt.ShouldNotBeNull();
        integrationOpt.ClientConfiguration.IsStorageConfiguration.ShouldBeTrue();
    }

    [Fact]
    public void OperationsIntegration_ClientConfiguration_Value_IsRestClient()
    {
        var knownName = new IntegrationName("MyRestClientName");
        var provider = SetupHelper.BuildConfigurationsServiceProvicer();
        var monitor = provider.GetRequiredService<IOptionsMonitor<OperationsIntegration>>();

        var integrationOpt = monitor.Get( knownName.Value );
        integrationOpt.ShouldNotBeNull();
        integrationOpt.ClientConfiguration.IsRestConfiguration.ShouldBeTrue();
    }
}
