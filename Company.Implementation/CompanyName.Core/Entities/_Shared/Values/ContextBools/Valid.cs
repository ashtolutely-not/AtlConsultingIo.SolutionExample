namespace CompanyName.Core.Entities;

public struct Valid
{
    public readonly bool Value;

    private Valid( bool input ) => Value = input;

    public static readonly Valid True = new( true );
    public static readonly Valid False = new( false );

    public static implicit operator bool( Valid _ ) => _.Value;

    public static Valid Create( bool value ) => new( value );
}
