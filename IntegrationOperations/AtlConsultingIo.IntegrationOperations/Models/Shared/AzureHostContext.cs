
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace AtlConsultingIo.IntegrationOperations;

public record AzureHostContext
{
    public string? ApplicationName { get; init; } 
    public string InstanceID { get; init; } = string.Empty;
    public string? EnvironmentName { get; init; } 
    public IFileProvider? ApplicationFileProvider { get; init; }
    public IFileProvider? WebRootFileProvider { get; init; }
    public string? ApplicationRoot {  get; init; }
    public string? WebRoot { get; init; }

    internal AzureHostContext()
    {
        WebRoot = Environment.GetEnvironmentVariable("HOME").EmptyIfNull();
        ApplicationName = Environment.GetEnvironmentVariable("WEBSITE_SITE_NAME").EmptyIfNull();
        InstanceID = Environment.GetEnvironmentVariable("WEBSITE_ROLE_INSTANCE_ID").EmptyIfNull();
        EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").EmptyIfNull();

    }
    public AzureHostContext( IConfigurationRoot configuration )
    {
        WebRoot = configuration["HOME"];
        ApplicationName = configuration["WEBSITE_SITE_NAME"];
        InstanceID = configuration[ "WEBSITE_ROLE_INSTANCE_ID" ].EmptyIfNull();
        EnvironmentName = configuration[ "ASPNETCORE_ENVIRONMENT" ];
    }
    public AzureHostContext WithHostEnvironment( IWebHostEnvironment environment )
    {
        return this with
        {
            ApplicationName = ApplicationName.HasValue() ? ApplicationName : environment.ApplicationName,
            EnvironmentName = EnvironmentName.HasValue() ? EnvironmentName : environment.EnvironmentName,   
            ApplicationRoot = environment.ContentRootPath,
            ApplicationFileProvider = environment.ContentRootFileProvider,
            WebRoot = WebRoot.HasValue() ? WebRoot : environment.WebRootPath,
            WebRootFileProvider = environment.WebRootFileProvider
        };
    }

    public AzureHostContext WithHostEnvironment( IHostEnvironment environment )
    {
        return this with
        {
            ApplicationName = ApplicationName.HasValue() ? ApplicationName : environment.ApplicationName,
            EnvironmentName = EnvironmentName.HasValue() ? EnvironmentName : environment.EnvironmentName,   
            ApplicationRoot = environment.ContentRootPath,
            ApplicationFileProvider = environment.ContentRootFileProvider
        };
    }
}

