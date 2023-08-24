namespace CompanyName.Core.Entities;


public struct EstDateTime :  IEquatable<DateOnly>, IEquatable<string?>
{
	public DateTime Value { get; }
    public EstDateTime( ) => Value = Now;

    public EstDateTime( DateTime dateTime )
    {
        if( dateTime.Kind != DateTimeKind.Utc )
        {
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dateTime);
            Value = TimeZoneInfo.ConvertTimeFromUtc( utc, Timezone );
        }
        else Value = TimeZoneInfo.ConvertTimeFromUtc(dateTime, Timezone );
    }

    public static readonly TimeZoneInfo Timezone 
        = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
    public static DateTime Now 
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, Timezone);

	public static implicit operator DateTime( EstDateTime _ ) => _.Value;
    public static implicit operator string( EstDateTime _ ) => _.Value.ToString();
	public bool Equals( DateOnly other ) 
        => DateOnly.FromDateTime(Value).Equals(other);
	public bool Equals( string? other )
	=> !string.IsNullOrWhiteSpace( other ) && Value.ToString().Equals( other );
}
