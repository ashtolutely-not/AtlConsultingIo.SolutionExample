namespace CompanyName.Core.Entities;

public struct CstDateTime : IEquatable<DateOnly>, IEquatable<string?>
{
    public DateTime Value { get; }
    public CstDateTime( DateTime dateTime )
    {
        if( dateTime.Kind != DateTimeKind.Utc )
        {
            DateTime utc = TimeZoneInfo.ConvertTimeToUtc(dateTime);
            Value = TimeZoneInfo.ConvertTimeFromUtc( utc, TimeZone );
        }
        else Value = TimeZoneInfo.ConvertTimeFromUtc(dateTime, TimeZone);
    }

    public CstDateTime( ) => Value = Now;

    public static implicit operator DateTime( CstDateTime _ ) => _.Value;
    public static implicit operator string( CstDateTime _ ) => _.Value.ToString();

    public static readonly TimeZoneInfo TimeZone 
        = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

    public static DateTime Now 
        => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, TimeZone);

	public bool Equals( DateOnly other ) => DateOnly.FromDateTime( Value ).Equals( other );
	public bool Equals( string? other ) 
        => !string.IsNullOrWhiteSpace(other) && Value.ToString().Equals(other);
}
