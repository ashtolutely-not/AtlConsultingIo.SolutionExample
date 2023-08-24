namespace CompanyName.Core.Entities.Order;

public struct PaymentAccountChargeAmount : IDecimalValue, IEquatable<decimal>, IEquatable<decimal?>
{
    public decimal Value { get; set; }
    public bool IsDefault => Value.Equals( 0 );

    private PaymentAccountChargeAmount( decimal value ) => Value = value;
    public static PaymentAccountChargeAmount Create( decimal? nullableValue )
        => new PaymentAccountChargeAmount( nullableValue ?? 0 );

    public static implicit operator decimal ( PaymentAccountChargeAmount _ )
        => _.Value;

    public static readonly PaymentAccountChargeAmount None = new( 0 );

	public bool Equals( decimal other ) => Value.Equals( other );
    public bool Equals( decimal? other ) => other.GetValueOrDefault().Equals( Value );
}
