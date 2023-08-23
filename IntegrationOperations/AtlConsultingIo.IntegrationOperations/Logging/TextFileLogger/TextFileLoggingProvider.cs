using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AtlConsultingIo.IntegrationOperations;

[ProviderAlias("TextFileLogger")]
public sealed class TextFileLoggingProvider : ILoggerProvider
{
    public readonly TextFileLoggingOptions Options;

    public TextFileLoggingProvider( IOptions<TextFileLoggingOptions> options )
    {
        Options = options.Value;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new LocalTextFileLogger(categoryName, this);
    }



    public void Dispose() { }


}
