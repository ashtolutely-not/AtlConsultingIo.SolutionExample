
using Microsoft.Extensions.Logging;

namespace AtlConsultingIo.IntegrationOperations;

public sealed class TextFileLoggingOptions
{

    public string LogFileName { get; set; } = String.Empty;
    public string LogDirectoryPath { get; set; } = String.Empty;
    public bool CreateFilePerCategory { get; set; } 
    public bool UseJsonFormatting { get; set; } = true;

    public LogLevel LogLevelFilter { get; set; }

    public static readonly TextFileLoggingOptions Default = new();
}
