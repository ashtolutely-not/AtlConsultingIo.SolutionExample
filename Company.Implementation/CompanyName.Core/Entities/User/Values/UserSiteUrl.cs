using CompanyName.Core;
using CompanyName.Core.Entities;
using CompanyName.Core.Entities.Events;
using CompanyName.Core.Entities.Messaging;
using CompanyName.Core.Entities.Order;
using CompanyName.Core.Entities.Product;
using CompanyName.Core.Entities.User;
using CompanyName.Core.Integrations;
using CompanyName.Core.Integrations.Exigo;
using CompanyName.Core.Integrations.Exigo.Rest;
using CompanyName.Core.Integrations.Exigo.Sql;
using CompanyName.Core.Integrations.KountApi;
using CompanyName.Core.Integrations.SendGridApi;
using Flurl;


namespace CompanyName.Core.Entities.User;
[DapperHandler]
[NewtonsoftConverter]
public record struct UserSiteUrl : IEquatable<string?>
{
    private static readonly TwoLetterISOCode _defaultLanguage = TwoLetterISOCode.English;
    private static readonly WebAlias _defaultAlias    = new("106");

    private const string _baseUrl = @"https://shop.totallifechanges.com/Home";

    private readonly string? _value;
    public string Value
        => !string.IsNullOrWhiteSpace( _value ) ? _value : 
            new Url( _baseUrl )
            .SetQueryParam( "lang" , LanguageCode.Value )
            .SetQueryParam( "sponsor" , SiteAlias.Value )
            .ToString();

    public WebAlias SiteAlias { get; private init; }
    public TwoLetterISOCode LanguageCode { get; private init; }

    public bool IsNullOrDefault 
        => string.IsNullOrWhiteSpace(Value) || Value.Equals( Default.Value, StringComparison.OrdinalIgnoreCase);

    public UserSiteUrl( string input )
    {
        _value = input;

        var url = new Url( input );
        var lang = url.QueryParams.FirstOrDefault( x => x.Name.Equals( "lang", StringComparison.OrdinalIgnoreCase ) );
        var sponsor = url.QueryParams.FirstOrDefault( x => x.Name.Equals( "sponsor", StringComparison.OrdinalIgnoreCase ) );

        SiteAlias = sponsor.Value is string _alias && !string.IsNullOrWhiteSpace(_alias)? new WebAlias( _alias ): _defaultAlias;
        LanguageCode = lang.Value is string _lang && !string.IsNullOrWhiteSpace(_lang) ? TwoLetterISOCode.Parse(_lang) : _defaultLanguage;
    }
    public UserSiteUrl()
    {
        _value = null;
        SiteAlias = _defaultAlias;
        LanguageCode = _defaultLanguage;
    }

    public UserSiteUrl( WebAlias alias , string? languageCode = null )
    {
        TwoLetterISOCode iso = TwoLetterISOCode.Parse( languageCode.EmptyIfNull() );
        LanguageCode = !iso.IsValid ? _defaultLanguage : iso;

        SiteAlias = alias.IsNullOrDefault ? _defaultAlias : alias;
        _value = new Url( _baseUrl )
            .SetQueryParam( "lang" , LanguageCode.Value )
            .SetQueryParam( "sponsor" , SiteAlias.Value )
            .ToString();
    }

    public UserSiteUrl( CustomerID customerID , string? languageCode = null )
    {
        TwoLetterISOCode iso = TwoLetterISOCode.Parse( languageCode.EmptyIfNull() );
        LanguageCode = !iso.IsValid ? _defaultLanguage : iso;

        SiteAlias = customerID.IsDefault ? _defaultAlias : new( customerID.Value.ToString() );
        _value = new Url( _baseUrl )
            .SetQueryParam( "lang" , LanguageCode.Value )
            .SetQueryParam( "sponsor" , SiteAlias.Value )
            .ToString();
	}

    public UserSiteUrl( WebAlias alias, TwoLetterISOCode languageCode )
    {
        SiteAlias = alias.IsNullOrDefault ? _defaultAlias : alias;
        LanguageCode = !languageCode.IsValid ?
                        _defaultLanguage : languageCode;
        _value = new Url( _baseUrl )
            .SetQueryParam( "lang" , LanguageCode.Value )
            .SetQueryParam( "sponsor" , SiteAlias.Value )
            .ToString();
    }

    public UserSiteUrl( CustomerID customerId, TwoLetterISOCode languageCode )
    {
        SiteAlias = customerId.IsDefault ? _defaultAlias : new WebAlias( customerId.Value.ToString() );
		LanguageCode = !languageCode.IsValid ?
				_defaultLanguage : languageCode;
        _value = new Url( _baseUrl )
            .SetQueryParam( "lang" , LanguageCode.Value )
            .SetQueryParam( "sponsor" , SiteAlias.Value )
            .ToString();
	}

    public static readonly UserSiteUrl Default = new ();

    public static explicit operator string( UserSiteUrl _ ) => _.Value;

	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && Value.Equals( other, StringComparison.OrdinalIgnoreCase );
}
