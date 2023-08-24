namespace CompanyName.Core.Integrations.SendGridApi;

public struct SGEnabled 
{
    [JsonProperty( "enable" )] 
    public bool Value { get; init; }
    public SGEnabled( bool value ) => Value = value;
    public bool IsTrue => Equals( True );
    public bool IsFalse => Equals( False );

    public static readonly SGEnabled True = new( true );
    public static readonly SGEnabled False = new( false );

    public static implicit operator SGEnabled( bool value ) => new( value );
    public static explicit operator bool( SGEnabled value ) => value.Value;
}
