namespace CompanyName.Core.Entities.Order;

public readonly record struct PointAcccountPaymentAmount : IEquatable<decimal> , IEquatable<decimal?>
{
    public readonly decimal Value;
    public bool IsDefault => Value.Equals( 0 );
    public PointAcccountPaymentAmount( decimal? value ) 
        => Value = value.GetValueOrDefault();

    public PointAcccountPaymentAmount( decimal value )
        => Value = value;

    public PointAcccountPaymentAmount( int? value )
        => Value = value.GetValueOrDefault();

    public static implicit operator decimal ( PointAcccountPaymentAmount _ )
        => _.Value;

    public static readonly PointAcccountPaymentAmount Default = new(  );
	public bool Equals( decimal other ) => Value.Equals( other );
	public bool Equals( decimal? other ) => other.GetValueOrDefault().Equals( Value );
}
