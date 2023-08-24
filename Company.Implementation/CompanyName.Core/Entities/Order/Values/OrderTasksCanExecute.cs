namespace CompanyName.Core.Entities.Order;

public  struct OrderTasksCanExecute : IBooleanValue, IEquatable<bool>, IEquatable<int>, IEquatable<int?>
{
    private static readonly int[] _processedStatuses = new int[]{ 7 , 8 , 9 };
    public bool Value { get; set; }
    private OrderTasksCanExecute( bool value ) => Value = value;

    public static implicit operator bool( OrderTasksCanExecute _ ) => _.Value;

    public static OrderTasksCanExecute Create( int status )
        => new OrderTasksCanExecute( _processedStatuses.Contains(status) );
	public bool Equals( bool other ) => Value.Equals( other );
	public bool Equals( int other ) => _processedStatuses.Contains( other );
	public bool Equals( int? other ) => _processedStatuses.Contains( other.GetValueOrDefault() );
}
