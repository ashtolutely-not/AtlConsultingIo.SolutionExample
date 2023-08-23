using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace AtlConsultingIo.IntegrationOperations;

public sealed class LocalTextFileLogger : ILogger
{
    private readonly TextFileLoggingProvider _provider;
    private readonly string _category;

    private readonly string _filePath;
    public LocalTextFileLogger( string categoryName , TextFileLoggingProvider textFileLogger )
    {
        _provider = textFileLogger;
        _category = categoryName;

        string name = _provider.Options.CreateFilePerCategory ? 
                        string.Format("{fileName}_{category}", _provider.Options.LogFileName, _category) : 
                        _provider.Options.LogFileName;

        _filePath = Path.Combine( _provider.Options.LogDirectoryPath, name );
    }

    public IDisposable? BeginScope<TState>( TState state ) where TState : notnull
    {
        return new NoopDisposable();
    }

    public bool IsEnabled( LogLevel logLevel )
    {   
        return logLevel != LogLevel.None && logLevel >= _provider.Options.LogLevelFilter;
    }

    public void Log<TState>( LogLevel logLevel , EventId eventId , TState state , Exception? exception , Func<TState , Exception? , string> formatter )
    {
        if ( !IsEnabled( logLevel ) )
            return;

        if ( !_provider.Options.UseJsonFormatting )
            using ( var sw = new StreamWriter( _filePath , true ) )
            {
                sw.WriteLine( GetLogHeader( logLevel ) );
                sw.Write( formatter( state , exception ) );
            }
        else
            using ( var sw = new StreamWriter( _filePath , true ) )
            {
                var entry = new JsonLogEntry<TState>
                {
                    Timestamp = DateTime.Now,
                    LogLevel = logLevel.ToString(),
                    EventId = eventId.Id,
                    EventName = eventId.Name,
                    Category = _category,
                    Exception = exception,
                    State = state
                };

                sw.Write( entry.ToFormattedJsonString() );
            }
    }



    private string GetLogHeader( LogLevel logLevel ) => $"[{DateTime.Now}][{logLevel.ToString()}][{_category}]";
    private class NoopDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}
