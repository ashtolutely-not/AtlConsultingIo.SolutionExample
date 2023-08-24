namespace CompanyName.Core.Entities;

public struct Enabled
{
    public readonly bool Value;
    private Enabled( bool input ) => Value = input;

    public static readonly Enabled True = new( true );
    public static readonly Enabled False = new( false );

    public static implicit operator bool( Enabled _ ) =>  _.Value;
}
