namespace CompanyName.Core.Entities;

public struct CartID : IStringValue, IEquatable<string?>
{
    public string Value { get; set; }
    public bool IsNullOrDefault => string.IsNullOrWhiteSpace(Value);
    public CartID( string? value ) 
        => Value = !string.IsNullOrWhiteSpace(value) ? value : String.Empty;

    public static implicit operator string( CartID _ ) => _.Value;

    public static readonly CartID Default = new();

	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && Value.Equals( other, StringComparison.OrdinalIgnoreCase );
}
