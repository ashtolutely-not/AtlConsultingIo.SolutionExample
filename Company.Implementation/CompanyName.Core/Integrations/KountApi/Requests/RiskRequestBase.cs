using System.ComponentModel.DataAnnotations;
using System.Text;

using AtlConsultingIo.IntegrationOperations;

namespace CompanyName.Core.Integrations.KountApi;

public class RiskRequestBase : IFormContent
{
    protected Dictionary<string , string?> FormValues { get; set; } = new()
    {
        [ "FRMT" ] = "JSON" ,
        [ "VERS" ] = "0630" ,
        [ "SDK" ] = ".NET" ,
        [ "SDK_VERSION" ] = "" ,
        [ "CURR" ] = "USD"
    };

    protected int? ValueAsInt( string key )
    {
        if( FormValues.TryGetValue( key, out var value ) )
            if( int.TryParse( value, out var valueAsInt ) )
                return valueAsInt;
        return null;
    }

    [Required]
    [RegularExpression( @"^\d{6}$" )]
    public int? MerchantId
    {
        get => ValueAsInt("MERC");
        set => FormValues[ "MERC" ] = value?.ToString();
    }

    public KountPaymentType PaymentType
    {
        get => Enum.TryParse<KountPaymentType>(FormValues[ "PYTP" ], out var result ) ? result : KountPaymentType.Default;
        set => FormValues[ "PYTP" ] = value.DisplayName ();
    }

    [RegularExpression( @"^[AD]$" )]
    [StringLength( 1 )]
    protected string? AuthorizationMode
    {
        get => FormValues[ "AUTH" ];
        set => FormValues[ "AUTH" ] = value;
    }

    [RegularExpression( @"^[YN]$" )]
    [StringLength( 1 )]
    protected string? MerchantAcknowledgementMode
    {
        get => FormValues[ "MACK" ];
        set => FormValues[ "MACK" ] = value;
    }

    [Required]
    [RegularExpression( @"^Q|P|U|X|W|J$" )]
    public string? RequestMode
    {
        get => FormValues[ "MODE" ];
        set => FormValues[ "MODE" ] = value;
    }

    [StringLength( 32 )]
    public string? SessionId
    {
        get => FormValues[ "SESS" ];
        set => FormValues[ "SESS" ] = value;
    }

    public string? CustomerId
    {
        get => FormValues[ "CUSTOMER_ID" ];
        set
        => FormValues[ "CUSTOMER_ID" ] = value;
    }

    public string? EncryptionType
    {
        get => FormValues[ "PENC" ];
        set => FormValues[ "PENC" ] = value;
    }

    public string? PaymentToken
    {
        get => FormValues[ "PTOK" ];
        set => FormValues[ "PTOK" ] = value;
    }

    [RegularExpression( @"^([a-zA-Z0-9]{4})?$" )]
    public string? TokenPartial
    {
        get => FormValues[ "LAST4" ];
        set => FormValues[ "LAST4" ] = value;
    }

    protected RiskRequestBase( string acknowledgementMode , string authorizedMode , string? encryption = null )
    {
        EncryptionType = encryption ?? _defaultEncryption;
        MerchantAcknowledgementMode = acknowledgementMode;
        AuthorizationMode = authorizedMode;
    }

    public FormUrlEncodedContent GetEncodedForm() => new( FormValues.Where( kvp => !string.IsNullOrWhiteSpace(kvp.Value)) );

    private const string _defaultEncryption = "KHASH";

    public virtual bool IsValid()
    {
        var valid = true;
        var errors = new List<ValidationResult> ();
        var props = GetType ().GetProperties ();
        foreach ( var p in props )
        {
            valid = Validator.TryValidateProperty( p.GetValue( this ) , new( this ) { MemberName = p.Name } , errors );
            if ( valid == false )
                break;
        }

        return valid;
    }

    private static string MaskValue( string value )
    {
        var builder = new StringBuilder ();

        builder.Append( value[ ..6 ] );
        for ( var i = 6; i < value.Length - 4; i++ ) builder.Append( 'X' );

        builder.Append( value[ ^4.. ] );

        return builder.ToString();
    }

    public void SetMerchant( string merchantId ) => MerchantId = Convert.ToInt32( merchantId );

    public void SetEncryptionType( string value ) => EncryptionType = value;

    public void AddUserDefinedField( string fieldName , string fieldValue ) => FormValues[ string.Format( "UDF[{0}]" , fieldName ) ] = fieldValue;

    public void SetPayment(
        string creditCardNumber ,
        string paymentToken )
    {
        var cardNumber = creditCardNumber ?? string.Empty;
        if ( cardNumber.Length.Equals( 0 ) )
        {
            SetNoPayment();
            return;
        }

        //PaymentType = KountPaymentType.CreditCard;
        if ( string.IsNullOrEmpty( TokenPartial ) )
            TokenPartial = cardNumber.Length > 4 ? cardNumber[ ^4.. ] : cardNumber;

        PaymentToken = paymentToken;
    }

    public void SetNoPayment() =>
            //PaymentType = KountPaymentType.None;
            PaymentToken = string.Empty;

    public void SetSessionId( string sessionId ) => SessionId = sessionId;
}
