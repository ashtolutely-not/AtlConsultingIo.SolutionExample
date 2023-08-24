namespace CompanyName.Core.Entities.Order;

public struct SalesOrderTotal : IDecimalValue, IEquatable<decimal>, IEquatable<decimal?>
{
    public decimal Value { get; set; }
    public bool IsDefault => Value.Equals( 0 );
    public SalesOrderTotal( decimal input )
        => Value = input;

    public SalesOrderTotal( decimal? input )
        => Value = input.GetValueOrDefault();

    public static implicit operator decimal( SalesOrderTotal _ ) => _.Value;

    public static readonly SalesOrderTotal Default = new();

	public bool Equals( decimal other ) => Value.Equals( other );
	public bool Equals( decimal? other ) => other.GetValueOrDefault().Equals(Value);
}
