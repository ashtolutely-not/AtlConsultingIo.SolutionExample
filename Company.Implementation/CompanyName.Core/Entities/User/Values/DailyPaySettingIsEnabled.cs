namespace CompanyName.Core.Entities.User;

[DapperHandler]
[NewtonsoftConverter]
public struct DailyPaySettingIsEnabled : IBooleanValue, IEquatable<bool>, IEquatable<string>
{
    private const string _enabled = "1";
    private const string _disabled = "0";

    public bool Value { get; set; }

    public DailyPaySettingIsEnabled( string input )
        => Value = input.Trim().Equals( _enabled );

    public DailyPaySettingIsEnabled( bool input )
        => Value = input;

    public bool True => Value.Equals( true );
    public bool False => Value.Equals( false );

    public static implicit operator bool( DailyPaySettingIsEnabled _ )
        => _.Value;

    public static implicit operator string( DailyPaySettingIsEnabled _ )
        => _.Value.Equals(true) ? _enabled : _disabled;

	public bool Equals( bool other ) => Value.Equals( other );
	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && _enabled.Equals( other );
}
