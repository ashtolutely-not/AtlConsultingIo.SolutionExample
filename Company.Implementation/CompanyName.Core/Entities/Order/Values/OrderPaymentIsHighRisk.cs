namespace CompanyName.Core.Entities.Order;

public readonly record struct OrderPaymentIsHighRisk : IEquatable<bool>, IEquatable<string>
{
	private const string _highRiskFlag = "IsReferenceNumber";
	public bool Value { get; }

    public OrderPaymentIsHighRisk( bool input ) => Value = input;

    public OrderPaymentIsHighRisk( string? input ) => Value = !string.IsNullOrWhiteSpace ( input )
            && input.Equals ( _highRiskFlag , StringComparison.OrdinalIgnoreCase );

    public static implicit operator bool( OrderPaymentIsHighRisk _ )
        => _.Value;

    public static implicit operator string( OrderPaymentIsHighRisk _ )
        => _.Value.Equals(true) ? _highRiskFlag : String.Empty;

	public bool Equals( bool other ) => Value.Equals( other );
	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) 
        && _highRiskFlag.Equals( other, StringComparison.OrdinalIgnoreCase );
}
