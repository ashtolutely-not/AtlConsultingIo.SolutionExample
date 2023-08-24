namespace CompanyName.Core.Entities;

public struct CheckoutIP : IStringValue, IEquatable<string?>
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace( Value );

    public CheckoutIP( string? input )
        => Value = input ?? String.Empty;

    public static implicit operator string( CheckoutIP _ ) => _.Value;
    public static readonly CheckoutIP Default = new( );

	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && Value.Equals( other , StringComparison.OrdinalIgnoreCase );
}
