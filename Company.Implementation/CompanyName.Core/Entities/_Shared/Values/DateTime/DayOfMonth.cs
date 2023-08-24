namespace CompanyName.Core.Entities;

public struct DayOfMonth : IEquatable<int>, IEquatable<int?>
{
	public readonly int Value;
    public bool IsDefault => Value.Equals( 0 );
	public DayOfMonth( int input ) => Value = input >=1 && input <= 31 ? input : Today;

	public DateTime GetSmartshipStartDate( DayOfMonth maxDayOfMonth )
    {
        var now = CstDateTime.Now;
        var isValidDay = this <= maxDayOfMonth;

        DateTime monthDate = isValidDay ? now.AddMonths( 1 ) : now.AddMonths( 2 );
        int dayDate = isValidDay ? this : DayOne;

        return new( monthDate.Year , monthDate.Month , dayDate , 3 , 0 , 0 );
    }

	public bool Equals( int other ) => Value.Equals( other );
	public bool Equals( int? other )
	=> Value.Equals( other.GetValueOrDefault() );

	public static implicit operator int( DayOfMonth _ )
		=> _.Value;

	public static readonly DayOfMonth Default = new();
	public static readonly DayOfMonth DayOne = new(1);
	public static DayOfMonth Today => new( DateTime.UtcNow.Day );
}
