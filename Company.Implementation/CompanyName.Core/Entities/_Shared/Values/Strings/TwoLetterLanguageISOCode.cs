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
using System.Globalization;

namespace CompanyName.Core.Entities;
[DapperHandler]
[NewtonsoftConverter]
public  struct TwoLetterISOCode : IEquatable<TwoLetterISOCode>, IEquatable<string?>
{
    private static readonly string[] _validCodes
        = System.Globalization.CultureInfo
            .GetCultures( CultureTypes.AllCultures )
            .Select( x => x.TwoLetterISOLanguageName.ToLower() )
            .Distinct()
            .ToArray();

    private const char _default = ' ';

    public readonly char FirstLetter;
    public readonly char SecondLetter;
    public string Value => new( FirstLetter, SecondLetter );
    public bool IsValid => FirstLetter != _default 
                            && SecondLetter != _default 
                            && _validCodes.Contains( Value.ToLower() );

    public TwoLetterISOCode()
    {
        FirstLetter = _default;
        SecondLetter = _default;
    }
    public TwoLetterISOCode( char firstLetter, char secondLetter )
    {
        if( char.IsLetter( firstLetter ) && char.IsLetter( secondLetter ) )
            (FirstLetter, SecondLetter) = (firstLetter, secondLetter);
        else (FirstLetter,SecondLetter) = (default, default);
    }

    public bool Equals( string? other ) => !string.IsNullOrWhiteSpace ( other ) && Value.Equals ( other , StringComparison.OrdinalIgnoreCase );
    public bool Equals( TwoLetterISOCode other ) => other.Value.Equals ( Value , StringComparison.OrdinalIgnoreCase );

    public static TwoLetterISOCode Parse( string input )
    {
		var letters = input.Where( c => char.IsLetter(c) );
        return letters.Count() >= 2 ? new( letters.ElementAt( 0 ) , letters.ElementAt( 1 ) ) : new();
    }
    public static readonly TwoLetterISOCode Default = new();
    public static readonly TwoLetterISOCode English = new('E','N');

    public static implicit operator string( TwoLetterISOCode _ )
        => _.Value;
}
