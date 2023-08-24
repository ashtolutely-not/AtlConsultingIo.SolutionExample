using OneOf;
namespace CompanyName.Core.Entities.Messaging;

public readonly record struct EmailTemplateID : IEquatable<string?>
{
    public OneOf<string,int> Value { get; }
    public bool IsNullOrDefault => Value.Match( str => string.IsNullOrWhiteSpace( str ), num => num <= 0 );
    public EmailTemplateID( string input )
        => Value = input;

    public EmailTemplateID ( int input )
        => Value = input.ToString();

    public static implicit operator int( EmailTemplateID _ ) 
        => _.Value.Match( str => 0 , num => num );

    public static implicit operator string( EmailTemplateID _ ) => _.Value.Match( str => str, num => String.Empty);

    public static readonly EmailTemplateID Default = new();

	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && Value.Match( str => other.CaseInsensitiveEquals(str), num => false );
}
