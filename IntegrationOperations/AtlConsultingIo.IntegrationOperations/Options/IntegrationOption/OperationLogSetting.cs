


using Microsoft.Extensions.Logging;

using System.Reflection.Emit;

namespace AtlConsultingIo.IntegrationOperations;

public record OperationLogSetting
{
    private static readonly Options _defaultOptions = new();
    public Options? Value { get; set; }

    public OperationLogSetting()
    {

    }

    public Options GetOptionOrDefault() 
        => Value ?? _defaultOptions;

    public record Options
    {
        public LogLevel ExceptionLogLevel { get; set; } = LogLevel.Warning;
        public bool ExceptionEventsEnabled { get; set; }
        public Dictionary<string , string>? CustomEventProperties { get; set; }
        public string[] StorageLogResultTypes { get; set; } = Array.Empty<string>();

        public Options()
        {
            
        }

        private List<OperationResultType>? _enabledLogTypes; 
        public List<OperationResultType> EnabledLogTypes
        {
            get
            {
                if( _enabledLogTypes is null )
                {
                    _enabledLogTypes = new List<OperationResultType>();
                    for ( int i = 0; i < StorageLogResultTypes.Length ; i++ )
                        if( Enum.TryParse<OperationResultType>( StorageLogResultTypes[i], out var type ))
                            _enabledLogTypes.Add( type );
                }

                return _enabledLogTypes;
            }
        }
    }

    public static readonly OperationLogSetting Default = new();
}



