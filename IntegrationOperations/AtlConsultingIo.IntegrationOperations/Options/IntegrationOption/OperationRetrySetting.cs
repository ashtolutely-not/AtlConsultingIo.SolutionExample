


namespace AtlConsultingIo.IntegrationOperations;

public record OperationRetrySetting
{
    private static readonly Options _defaultOptions = new Options();    
    public bool Enabled { get; set; }
    public Options? Value { get; set; }

    public static readonly OperationRetrySetting Default = new();

    public OperationRetrySetting()
    {
        
    }

    public OperationRetrySetting( OperationRetrySetting.Options options )
    {
        Enabled = true;
        Value = options;
    }

    public record Options
    {
        [JsonConverter( typeof( StringEnumConverter ) )]
        public RetryDelayStrategy RetryDelayStrategy { get; set; }
        public int MaxRetryAttempts { get; set; }

        public int InitialDelayMs { get; set; }
        public int MinDelayMs { get; set; }
        public int MaxDelayMs { get; set; }
        public int ConstantDelayMs { get; set; }
        public int MedianDelayMs { get; set; }

        public TimeSpan InitialDelayInMilliseconds 
            => TimeSpan.FromMilliseconds( InitialDelayMs );
        public TimeSpan MinDelayInMilliseconds 
            => TimeSpan.FromMilliseconds( MinDelayMs );
        public TimeSpan MaxDelayInMilliseconds 
            => TimeSpan.FromMilliseconds( MaxDelayMs );
        public TimeSpan ConstantDelayInMilliseconds 
            => TimeSpan.FromMilliseconds( ConstantDelayMs );
        public TimeSpan MedianDelayInMilliseconds 
            => TimeSpan.FromMilliseconds( MedianDelayMs );

        public Options()
        {
            MaxRetryAttempts = 4;
            RetryDelayStrategy = RetryDelayStrategy.Jitter;
            InitialDelayMs =  1000 ;
            MinDelayMs =  500 ;
            MaxDelayMs = 3000;
            ConstantDelayMs = 1000;
            MedianDelayMs = 1000;
        }
    }

    public Options GetOptionsOrDefault() => Value ?? _defaultOptions;
}
