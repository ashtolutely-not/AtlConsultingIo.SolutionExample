using System.ComponentModel.DataAnnotations;

namespace CompanyName.Core.Integrations.KountApi;
public class RiskTransactionInquiry : RiskRequestBase
{
    [JsonProperty( "TOTL" )]
    [RegularExpression( @"^\d{1,15}$" )]
    public int ChargeAmount
    {
        get => ValueAsInt( "TOTL" ) ?? 0;
        set => FormValues["TOTL"] = value.ToString();
    }

    [JsonIgnore]

    public List<KountLineItem> LineItems { get; set; } = new();

    [RegularExpression( @"^.+@.+\..+$" )]
    public string? EmailAddress
    {
        get => FormValues[ "EMAL" ];
        set => FormValues[ "EMAL" ] = value;
        
    }

    [StringLength( 64 )]
    public string? Name
    {
        get => FormValues[ "NAME" ];
        set => FormValues[ "NAME" ] = value;
    }

    [StringLength( 45 )]
    public string? ClientIp
    {
        get => FormValues[ "IPAD" ];
        set=> FormValues[ "IPAD" ] = value;
    }

    [StringLength( 256 )]
    public string? BillingAddressLine1
    {
        get => FormValues[ "B2A1" ];
        set => FormValues[ "B2A1" ] = value;
    }

    [StringLength( 255 )]
    public string? BillingAddressLine2
    {
        get => FormValues[ "B2A2" ];
        set => FormValues[ "B2A2" ] = value;
    }

    [StringLength( 255 )]
    public string? BillingCity
    {
        get => FormValues[ "B2CI" ];
        set => FormValues[ "B2CI" ] = value;
    }

    [StringLength( 255 )]
    public string? BillingState
    {
        get => FormValues[ "B2ST" ];
        set => FormValues[ "B2ST" ] = value;
    }

    [StringLength( 16 )]
    public string? BillingPostalCode
    {
        get => FormValues[ "B2PC" ];
        set => FormValues[ "B2PC" ] = value;
    }

    [StringLength( 2 )]
    public string? BillingCountry
    {
        get => FormValues[ "B2CC" ];
        set => FormValues[ "B2CC" ] = value;
    }

    [StringLength( 32 )]
    public string? BillingPhoneNumber
    {
        get => FormValues[ "B2PN" ] ;
        set => FormValues[ "B2PN" ] = value;
    }

    [StringLength( 64 )]
    public string? ShippingName
    {
        get => FormValues[ "S2NM" ];
        set => FormValues[ "S2NM" ] = value;
    }

    [StringLength( 64 )]
    [RegularExpression( @"^.+@.+\..+$" )]
    public string? ShippingEmail
    {
        get => FormValues[ "S2EM" ];
        set => FormValues[ "S2EM" ] = value;
    }

    [StringLength( 256 )]
    public string? ShippingAddressLine1
    {
        get => FormValues[ "S2A1" ];
        set => FormValues[ "S2A1" ] = value;
    }

    [StringLength( 256 )]
    public string? ShippingAddressLine2
    {
        get => FormValues[ "S2A2" ];
        set => FormValues[ "S2A2" ] = value;
    }

    [StringLength( 256 )]
    public string? ShippingCity
    {
        get => FormValues[ "S2CI" ];
        set => FormValues[ "S2CI" ] = value;
    }

    [StringLength( 256 )]
    public string? ShippingState
    {
        get => FormValues[ "S2ST" ];
        set => FormValues[ "S2ST" ] = value;
    }

    [StringLength( 16 )]
    public string? ShippingPostalCode
    {
        get => FormValues[ "S2PC" ];
        set => FormValues[ "S2PC" ] = value;
    }

    [StringLength( 2 )]
    public string? ShippingCountry
    {
        get => FormValues[ "S2CC" ];
        set => FormValues[ "S2CC" ] = value;
    }

    [StringLength( 32 )]
    public string? ShippingPhoneNumber
    {
        get => FormValues[ "S2PN" ];
        set => FormValues[ "S2PN" ] = value;
    }

    [StringLength( 8 )]
    public string? SourceSite
    {
        get => FormValues[ "SITE" ];
        set => FormValues[ "SITE" ] = value;
    }

    public RiskTransactionInquiry( string? encryption = null ) : base( "Y" , "A" , encryption )
    {
        RequestMode = KountInquiryType.WebOrderInquiry.ToString();
        SetSessionId( Guid.NewGuid().ToString().Replace( "-" , "" ) );
    }

    public override bool IsValid() => LineItems.All( i => i.IsValid() ) && base.IsValid();
}
