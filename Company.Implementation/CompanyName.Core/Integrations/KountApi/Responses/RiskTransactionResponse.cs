using Newtonsoft.Json.Linq;

namespace CompanyName.Core.Integrations.KountApi;

public record RiskTransactionResponse
{
    private readonly JObject _data;

    [JsonIgnore]
    public bool IsFraudResponse => !string.IsNullOrEmpty( Mode ) && Mode!.ToUpper().Equals( "E" ) || AutomatedResponse.Equals( AutomatedResponseType.Declined );

    public bool IsEmpty => Equals( Empty );
    public RiskTransactionResponse( ) => _data = new ( );
    public RiskTransactionResponse( JObject json )
    {
        _data = json;

        ErrorCount = _data.Value<int?>( "ERROR_COUNT" ) ?? 0;
        WarningCount = _data.Value<int?>( "WARNING_COUNT" ) ?? 0;
        TriggeredRulesCount = _data.Value<int?>( "RULES_TRIGGERED" ) ?? 0;
        EmailAddressTransactionCount = _data.Value<int?>( "EMAILS" ) ?? 0;

        TransactionId = _data.Value<string?>( "TRAN" );
        ServerErrorCode = _data.Value<string?>( "ERRO" );
        ServerResponseVersion = _data.Value<string?>( "VERS" );
        Mode = _data.Value<string?>( "MODE" );
        HasKaptcha = _data.Value<bool?>( "KAPT" );
        IsKnowYourCustomerMatch = _data.Value<bool?>( "KYCF" );
        AutomatedResponse = Enum.TryParse<AutomatedResponseType>( _data.Value<string?>( "AUTO" ) ?? string.Empty , out var res ) ?
                            res : AutomatedResponseType.NeedsReview;

    }

    public static readonly RiskTransactionResponse Empty = new();

    private IEnumerable<PaymentRiskRule> ParseRules()
    {
        if ( TriggeredRulesCount.Equals( 0 ) )
            return Enumerable.Empty<PaymentRiskRule>();

        List<PaymentRiskRule> rules = new(TriggeredRulesCount);
        for ( var i = 0; i < TriggeredRulesCount; i++ )
        {
            var ruleId = _data.Value<string>($"RULE_ID_{i}");
            var ruleDesc = _data.Value<string>($"RULE_DESCRIPTION_{i}");

            if ( !string.IsNullOrEmpty( ruleId ) && !string.IsNullOrEmpty( ruleDesc ) )
                rules.Add( new( ruleId! , ruleDesc! ) );
        }

        return rules;
    }

    private IEnumerable<string> ParseErrors()
    {
        if ( ErrorCount.Equals( 0 ) )
            return Enumerable.Empty<string>();

        var errors = new List<string>(ErrorCount);
        for ( var i = 0; i < ErrorCount; i++ )
            if ( _data.TryGetValue( $"ERROR_{i}" , out var token ) )
                if ( token.Value<string>() is not null )
                    errors.Add( token.Value<string>()! );

        return errors;
    }

    private IEnumerable<string> ParseWarnings()
    {
        if ( WarningCount.Equals( 0 ) )
            return Enumerable.Empty<string>();

        var warnings = new List<string>(WarningCount);
        for ( var i = 0; i < WarningCount; i++ )
            if ( _data.TryGetValue( $"WARNING_{i}" , out var token ) )
                if ( token.Value<string>() is not null )
                    warnings.Add( token.Value<string>()! );

        return warnings;
    }

    public int ErrorCount { get; init; }
    public int TriggeredRulesCount { get; init; }
    public int WarningCount { get; init; }
    public int EmailAddressTransactionCount { get; init; }
    public bool? HasKaptcha { get; init; }
    public bool? IsKnowYourCustomerMatch { get; init; }
    public string? Mode { get; init; }
    public string? ServerErrorCode { get; init; }
    public string? ServerResponseVersion { get; init; }
    public string? TransactionId { get; init; }
    public AutomatedResponseType AutomatedResponse { get; init; }

    [JsonProperty( "SESS" )]
    public string? SessionId { get; init; }

    [JsonProperty( "MERC" )]
    public string? MerchantId { get; init; }

    [JsonProperty( "ORDR" )]
    public string? OrderId { get; init; }

    [JsonProperty( "SITE" )]
    public string? SiteId { get; init; }

    public BrowserAttributesResponse ClientBrowserResponse
    => new ()
    {
        IsUsingProxy = _data.Value<bool>( "PROXY" ) ,
        UserAgent = _data.Value<string>( "UAS" ) ,
        OperatingSystem = _data.Value<string>( "OS" ) ,
        NetworkType = _data.Value<string>( "NETW" ) ,
        BrowserType = _data.Value<string>( "BROWSER" ) ,
        GeoLocation = _data.Value<string>( "GEOX" )
    };

    public CreditCardMetricsResponse CreditCardResponse
        => new ()
        {
            Score = _data.Value<int?>( "SCOR" ) ,
            OmniScore = _data.Value<int?>( "OMNISCORE" ) ,
            TotalTransactionCount = _data.Value<int?>( "CARDS" ) ,
            SixHourTransactionCount = _data.Value<int?>( "VELO" ) ,
            TwoWeekTransactionCount = _data.Value<int?>( "VMAX" ) ,
            Brand = _data.Value<string?>( "BRND" ) ,
            CreditCardRegion = _data.Value<string?>( "REGN" ) ,
            MerchantReasonCode = _data.Value<string?>( "REASON_CODE" )
        };

    public DeviceResponse DeviceResponse
        => new ()
        {
            IsRemotelyControlled = _data.Value<bool?>( "PC_REMOTE" ) ,
            SupportsJavascript = _data.Value<bool?>( "JAVASCRIPT" ) ,
            SupportsCookies = _data.Value<bool?>( "COOKIES" ) ,
            SupportsFlash = _data.Value<bool?>( "FLASH" ) ,
            IsVoiceControlled = _data.Value<bool?>( "VOICE_DEVICE" ) ,
            IsMobileDevice = _data.Value<bool?>( "MOBILE_DEVICE" ) ,
            TransactionCount = _data.Value<int?>( "DEVICES" ) ,
            Timezone = _data.Value<string?>( "TIMEZONE" ) ,
            SystemLayers = _data.Value<string?>( "DEVICE_LAYERS" ) ,
            BrowserCountry = _data.Value<string?>( "HTTP_COUNTRY" ) ,
            Fingerprint = _data.Value<string?>( "FINGERPRINT" ) ,
            Protocol = _data.Value<string?>( "MOBILE_FORWARDER" ) ,
            ScreenResolution = _data.Value<string?>( "DSR" ) ,
            Type = _data.Value<string?>( "MOBILE_TYPE" ) ,
            Language = _data.Value<string?>( "LANGUAGE" ) ,
            Country = _data.Value<string?>( "COUNTRY" ) ,
            LocalDateTime = _data.Value<DateTime?>( "LOCALTIME" ) ,
            FirstSeenDate = _data.Value<DateTime?>( "DDFS" )
        };

    public ClientIPResponse IpResponse
        => new ()
        {
            Address = _data.Value<string?>( "IPAD" ) ,
            Latitude = _data.Value<string?>( "IP_LAT" ) ,
            Longitude = _data.Value<string?>( "IP_LON" ) ,
            City = _data.Value<string?>( "IP_CITY" ) ,
            Region = _data.Value<string?>( "IP_REGION" ) ,
            Country = _data.Value<string?>( "IP_COUNTRY" ) ,
            Organization = _data.Value<string?>( "IP_ORG" )
        };

    public ClientIPResponse PiercedIpResponse
        => new ()
        {
            Address = _data.Value<string?>( "PIP_IPAD" ) ,
            Latitude = _data.Value<string?>( "PIP_LAT" ) ,
            Longitude = _data.Value<string?>( "PIP_LON" ) ,
            City = _data.Value<string?>( "PIP_CITY" ) ,
            Region = _data.Value<string?>( "PIP_REGION" ) ,
            Country = _data.Value<string?>( "PIP_COUNTRY" ) ,
            Organization = _data.Value<string?>( "PIP_ORG" )
        };

    public IEnumerable<string> Warnings => ParseWarnings();
    public IEnumerable<string> Errors => ParseErrors();
    public IEnumerable<PaymentRiskRule> RulesTriggered => ParseRules();

}
