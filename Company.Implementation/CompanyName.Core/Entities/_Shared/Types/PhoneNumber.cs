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
namespace CompanyName.Core.Entities;

public record PhoneNumber : IEquatable<string?>
{
    public CountryDialCode DialCode { get; init; }
    public string AreaCode { get; init; }
    public string Prefix { get; init; }
    public string LineNumber { get; init; }
    public string Value { get; init; }
    public CleanPhoneNumber CleanValue => new( Value );
    public UIDisplayString DisplayValue  => new($"{ DialCode.Code } ({AreaCode}) {Prefix}-{LineNumber}");
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace(Value);
    public bool IsQualified => AreaCode.HasValue() && Prefix.HasValue() && LineNumber.HasValue();

    [JsonConstructor]
    private PhoneNumber()
    {
        DialCode = CountryDialCodeList.US;
        AreaCode = Prefix = LineNumber = Value = String.Empty;
    }

    public bool Equals( string? other )
        => !string.IsNullOrWhiteSpace( other ) && other.Any( c => char.IsDigit( c ) ) && Value.Equals( new string( other.Where( c => char.IsDigit(c)).ToArray()) );

    public static implicit operator string ( PhoneNumber _ ) => _.Value;

    public static PhoneNumber Parse( string? value )
    {
        if( string.IsNullOrWhiteSpace(value))
            return Default;

        var clean = new CleanPhoneNumber( value );
        if( string.IsNullOrWhiteSpace( clean ))
            return Default;

        (var lineNumber, var remainder) = ParseFromEnd( clean , LineNumberLength );
        (var prefix, remainder) = ParseFromEnd( remainder, PrefixLength );
        (var areaCode, remainder ) = ParseFromEnd( remainder, AreaCodeLength );

        CountryDialCode _code = 
            String.IsNullOrWhiteSpace( remainder ) || remainder.Trim().Equals("1") ?
            CountryDialCodeList.US :
            CountryDialCodeList.Values.FirstOrDefault( c => c.Code == $"+{remainder}");

        return new PhoneNumber
        {
            DialCode = _code,
            AreaCode = areaCode,
            Prefix = prefix,
            LineNumber = lineNumber,
            Value = value
        };
    }

    const int LineNumberLength = 4;
    const int PrefixLength = 3;
    const int AreaCodeLength = 3;
    static (string ParsedValue, string Remainder ) ParseFromEnd( string input , int characterCount )
    {
        var parsed = input.Length >= characterCount ? input[^characterCount..] : String.Empty;
        var remainder = input.Length > characterCount ? input.Substring( 0 , input.Length - characterCount  ) : String.Empty;
        return (parsed,remainder);
    }

    public static readonly PhoneNumber Default = new();

}

public struct CleanPhoneNumber
{
    public readonly string Value;
    public CleanPhoneNumber( string dirtyValue ) => Value = new string ( dirtyValue.Where ( Char.IsDigit ).ToArray ( ) );

    public static implicit operator string( CleanPhoneNumber _ ) => _.Value;
}
