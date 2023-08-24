using System.ComponentModel.DataAnnotations;

using Newtonsoft.Json.Linq;
namespace CompanyName.Core.Integrations.KountApi;

public record CreditCardMetricsResponse
{
    public int? OmniScore { get; init; }
    public int? Score { get; init; }
    public int? SixHourTransactionCount { get; init; }
    public int? TotalTransactionCount { get; init; }
    public int? TwoWeekTransactionCount { get; init; }
    public string? Brand { get; init; }
    public string? CreditCardRegion { get; init; }
    public string? MerchantReasonCode { get; init; }
}

public record BrowserAttributesResponse
{
    public bool? IsUsingProxy { get; init; }
    public string? BrowserType { get; init; }
    public string? GeoLocation { get; init; }
    public string? NetworkType { get; init; }
    public string? OperatingSystem { get; init; }
    public string? UserAgent { get; init; }
}

public record ClientIPResponse
{
    public string? Address { get; init; }
    public string? Latitude { get; init; }
    public string? Longitude { get; init; }
    public string? City { get; init; }
    public string? Region { get; init; }
    public string? Country { get; init; }
    public string? Organization { get; init; }
}

public record PaymentRiskRule
{
    public string RuleId { get; init; } = String.Empty;
    public string RuleDescription { get; init; } = String.Empty;

    public PaymentRiskRule()
    {
        
    }

    public PaymentRiskRule( string id , string description ) => (RuleId, RuleDescription) = (id, description);
}

public record KountLineItem
{
    [JsonIgnore]
    public decimal? ProductPrice { get; init; }

    [JsonProperty( "PROD_QUANT[{0}]" )]
    [RegularExpression( @"^[0-9]+$" )]
    public int ProductQuantity { get; init; }

    [JsonProperty( "PROD_PRICE[{0}]" )]
    [RegularExpression( @"^[0-9]+$" )]
    public long? KountFormattedPrice => ProductPrice is null ? null : Convert.ToInt64( ProductPrice * 100 );

    [JsonProperty( "PROD_TYPE[{0}]" )]
    [StringLength( 255 )]
    public string ProductType { get; init; } = String.Empty;

    [JsonProperty( "PROD_ITEM[{0}]" )]
    [StringLength( 255 )]
    public string ProductItem { get; init; } = String.Empty;

    [JsonProperty( "PROD_DESC[{0}]" )]
    [StringLength( 255 )]
    public string ProductDescription { get; init; } = String.Empty;

    public bool IsValid()
    {
        var valid = true;
        var errors = new List<ValidationResult>();
        var props = GetType().GetProperties();
        foreach ( var p in props )
        {
            valid = Validator.TryValidateProperty( p.GetValue( this ) , new( this ) { MemberName = p.Name } , errors );
            if ( valid == false )
                break;
        }

        return valid;
    }

    public List<KeyValuePair<string , string>> FormFields( int index )
    {
        var list = new List<KeyValuePair<string, string>>();
        var jobject = JObject.FromObject(this);
        var props = jobject.Properties();

        if ( props.Any() )
            foreach ( var p in props )
                list.Add( new( string.Format( p.Name , index ) , p.Value.ToString() ) );

        return list;
    }
}

public record DeviceResponse
{
    public bool? IsMobileDevice { get; init; }
    public bool? IsRemotelyControlled { get; init; }
    public bool? IsVoiceControlled { get; init; }
    public bool? SupportsCookies { get; init; }
    public bool? SupportsFlash { get; init; }
    public bool? SupportsJavascript { get; init; }
    public DateTime? FirstSeenDate { get; init; }
    public DateTime? LocalDateTime { get; init; }
    public int? TransactionCount { get; init; }
    public string? BrowserCountry { get; init; }
    public string? Country { get; init; }
    public string? Fingerprint { get; init; }
    public string? Language { get; init; }
    public string? Protocol { get; init; }
    public string? ScreenResolution { get; init; }
    public string? SystemLayers { get; init; }
    public string? Timezone { get; init; }
    public string? Type { get; init; }
}
