namespace CompanyName.Core.Entities;

public struct ShoppingCartTotal : IDecimalValue, IEquatable<decimal?>, IEquatable<decimal>
{
    public decimal Value { get; set; }
    public bool IsDefault => Value.Equals( 0 );
    public ShoppingCartTotal( decimal? input )
        => Value = input.GetValueOrDefault();

    public static implicit operator decimal( ShoppingCartTotal _ ) => _.Value;

    public static readonly ShoppingCartTotal Default = new();
	public bool Equals( decimal other ) => Value.Equals( other );
	public bool Equals( decimal? other ) => Value.Equals( other.GetValueOrDefault() );
}
