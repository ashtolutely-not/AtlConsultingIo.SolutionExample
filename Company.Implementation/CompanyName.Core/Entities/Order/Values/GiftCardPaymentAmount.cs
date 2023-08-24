namespace CompanyName.Core.Entities.Order;
[DapperHandler]
[NewtonsoftConverter]
public struct GiftCardPaymentAmount : IDecimalValue, IEquatable<decimal>, IEquatable<decimal?>
{
	public decimal Value { get; set; }
	public bool IsDefault => Value.Equals( 0 );
	public GiftCardPaymentAmount( decimal? value )
		=> Value = value.GetValueOrDefault();

	public static implicit operator decimal( GiftCardPaymentAmount _ )
		=> _.Value;

	public static readonly GiftCardPaymentAmount Default = new(  );
	public bool Equals( decimal other ) => Value.Equals( other );
	public bool Equals( decimal? other ) => other.GetValueOrDefault().Equals( Value );
}
