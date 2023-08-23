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

public record CountryCode : IEquatable<string?>
{
    public char FirstLetter { get; init; }  
    public char SecondLetter { get; init; }

    public string Value => new( FirstLetter, SecondLetter );
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace(Value);

    public CountryCode()
    {

    }
    private CountryCode( string value )
    {
        var letters = value.Where( c => char.IsLetter(c) );
        if( letters.Count() >= 2 )
            (FirstLetter,SecondLetter) = (letters.ElementAt(0), letters.ElementAt(1));
        else FirstLetter = SecondLetter = default;
    }
    public CountryCode( char firstLetter, char secondLetter )
    {
        if ( char.IsLetter( firstLetter ) && char.IsLetter( secondLetter ) )
            (FirstLetter, SecondLetter) = (firstLetter, secondLetter);
        else
            FirstLetter = SecondLetter = default;
    }

    public static CountryCode Parse( string value ) => new( value );
    public static readonly CountryCode Default = new();
    public static readonly CountryCode US = new('U','S');

    public bool Equals( string? other ) => !string.IsNullOrWhiteSpace ( other ) && Value.Equals ( other , StringComparison.OrdinalIgnoreCase );
    public static implicit operator string( CountryCode _ ) => _.Value;
}
